import { getYsqFormByIdOptions } from "#/common/api/generated/client"
import { btn } from "#/common/atoms/btn"
import { Base } from "#/common/layouts/base"
import { YsqQuestionsRepo } from "#/routes/forms/young-schema/questions/-ysq-questions-repo"
import { ArrowLeftIcon } from "@phosphor-icons/react"
import { useQuery } from "@tanstack/react-query"
import { createFileRoute, Link } from "@tanstack/react-router"

export const Route = createFileRoute("/admin/entries/$entryId")({
  component: RouteComponent,
})

const Responses = {
  CompletelyFalse: "کاملا غلط",
  MostlyFalse: "تقریبا غلط",
  SlightlyFalse: "کمی غلط",
  SlightlyTrue: "کمی درست",
  MostlyTrue: "تقریبا درست",
  CompletelyTrue: "کاملا درست",
}

function RouteComponent() {
  const { entryId } = Route.useParams()
  const { data } = useQuery(getYsqFormByIdOptions({ path: { ysqFormId: entryId } }))

  if (!data) return <Base className="py-4 px-4">Loading...</Base>

  return (
    <Base className="py-4 px-4 gap-6 max-w-7xl">
      <div className="mb-4 flex gap-1 items-center">
        <Link to="/admin/entries" className={btn({ isIcon: false, variant: "secondary" })}>
          <ArrowLeftIcon mirrored size={32} />
          <h1 className="font-bold text-slate-950 text-2xl">فرم ارسال‌شده</h1>
        </Link>
      </div>

      {/* === Personal Info / Summary Cards === */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4">
        <div className="p-4 border rounded-lg shadow-sm bg-white">
          <h2 className="font-bold mb-2">اطلاعات شخصی</h2>
          <ul className="space-y-1">
            <li>
              <strong>نام:</strong> {data.fullName}
            </li>
            <li>
              <strong>سن:</strong> {data.age}
            </li>
            <li>
              <strong>جنسیت:</strong> {data.gender}
            </li>
            <li>
              <strong>تلفن:</strong> {data.phone}
            </li>
          </ul>
        </div>

        <div className="p-4 border rounded-lg shadow-sm bg-white">
          <h2 className="font-bold mb-2">تحصیلات و شغل</h2>
          <ul className="space-y-1">
            <li>
              <strong>مدرک:</strong> {data.degree}
            </li>
            <li>
              <strong>رشته:</strong> {data.educationMajor}
            </li>
            <li>
              <strong>شغل:</strong> {data.jobTitle}
            </li>
          </ul>
        </div>
      </div>

      {/* === Answers Matrix Table === */}
      <div className="overflow-x-auto mt-6">
        <h2 className="font-bold text-lg mb-2">پاسخ‌ها</h2>
        <table className="w-full min-w-min border-collapse border border-slate-300">
          <thead>
            <tr className="bg-slate-100">
              <th className="border border-slate-300 px-4 py-2">#</th>
              <th className="border border-slate-300 px-4 py-2">تگ</th>
              <th className="border border-slate-300 px-4 py-2">سوال</th>
              {Object.values(Responses).map(resp => (
                <th key={resp} className="border border-slate-300 px-4 py-2 text-center">
                  {resp}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {data.answers.map(a => {
              const question = YsqQuestionsRepo.getQuestionByIndex(a.questionIndex)
              return (
                <tr key={a.questionIndex} className="hover:bg-slate-50">
                  <td className="border border-slate-300 px-4 py-2 text-center">{a.questionIndex}</td>
                  <td className="border border-slate-300 px-4 py-2">{question?.tag || "-"}</td>
                  <td className="border border-slate-300 px-4 py-2">{question?.title}</td>
                  {Object.keys(Responses).map(resp => (
                    <td key={resp} className="border border-slate-300 px-4 py-2 text-center">
                      {a.ysqResponse === resp ? "✅" : "-"}
                    </td>
                  ))}
                </tr>
              )
            })}
          </tbody>
        </table>
      </div>
    </Base>
  )
}
