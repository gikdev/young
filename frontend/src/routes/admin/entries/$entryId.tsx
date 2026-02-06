import { getYsqFormByIdOptions } from "#/common/api/generated/client"
import { Field } from "#/common/atoms/field"
import { Input } from "#/common/atoms/input"
import { Base } from "#/common/layouts/base"
import { YsqQuestionsRepo } from "#/routes/forms/young-schema/questions/-ysq-questions-repo"
import { useQuery } from "@tanstack/react-query"
import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute("/admin/entries/$entryId")({
  component: RouteComponent,
})

function RouteComponent() {
  const { entryId } = Route.useParams()
  const { data } = useQuery(getYsqFormByIdOptions({ path: { ysqFormId: entryId } }))

  return (
    <Base className="py-4 px-4 gap-4">
      <h1 className="font-bold text-slate-950 text-2xl">فرم ارسال‌شده</h1>

      <Field title="نام و نام خانوادگی">
        <Input defaultValue={data?.fullName} readOnly />
      </Field>

      <Field title="سن">
        <Input defaultValue={data?.age} readOnly />
      </Field>

      <Field title="مدرک">
        <Input defaultValue={data?.degree} readOnly />
      </Field>

      <Field title="رشته">
        <Input defaultValue={data?.educationMajor} readOnly />
      </Field>

      <Field title="جنسیت">
        <Input defaultValue={data?.gender} readOnly />
      </Field>

      <Field title="شغل">
        <Input defaultValue={data?.jobTitle} readOnly />
      </Field>

      <Field title="تلفن">
        <Input defaultValue={data?.phone} readOnly />
      </Field>

      {data?.answers.map(a => (
        <div key={a.questionIndex}>
          <p>{YsqQuestionsRepo.getQuestionByIndex(a.questionIndex)?.title}</p>
          <p>{a.ysqResponse}</p>
        </div>
      ))}
    </Base>
  )
}
