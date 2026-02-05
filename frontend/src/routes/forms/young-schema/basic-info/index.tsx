import { btn } from "#/common/atoms/btn"
import { useAppForm } from "#/common/forms"
import { Base } from "#/common/layouts/base"
import { useAppDispatch, useAppSelector } from "#/common/store"
import { ArrowLeftIcon, ArrowRightIcon } from "@phosphor-icons/react"
import { createFileRoute, Link, useNavigate } from "@tanstack/react-router"

import { youngSchemaFormSlice } from "../-store"
import { title } from "../content.json"

import { BasicInfoSchema } from "./-basic-info-schema"

export const Route = createFileRoute("/forms/young-schema/basic-info/")({
  component: RouteComponent,
})

function RouteComponent() {
  const basicInfo = useAppSelector(s => s.forms.youngSchemaForm.basicInfo)
  const dispatch = useAppDispatch()
  const navigate = useNavigate()

  const form = useAppForm({
    defaultValues: basicInfo,
    validators: {
      onChange: BasicInfoSchema,
    },
    onSubmit({ value }) {
      dispatch(youngSchemaFormSlice.actions.setBasicInfo(value))
      navigate({ to: "/forms/young-schema/questions/$qIndex", params: { qIndex: 1 } })
    },
  })

  return (
    <Base className="py-4 px-4 gap-4">
      <h1 className="font-bold text-center text-slate-950 text-2xl">{title}</h1>

      <form.AppForm>
        <form.AppField name="fullName">{field => <field.TextField label="نام و نام خانوادگی" />}</form.AppField>

        <form.AppField name="age">{field => <field.NumberField label="سن" />}</form.AppField>

        <form.AppField name="gender">
          {field => (
            <field.NativeSelectField
              label="جنسیت"
              options={[
                { value: "male", label: "مرد" },
                { value: "female", label: "زن" },
              ]}
            />
          )}
        </form.AppField>

        <form.AppField name="degree">{field => <field.TextField label="مدرک" />}</form.AppField>

        <form.AppField name="major">{field => <field.TextField label="رشته تحصیلی" />}</form.AppField>

        <form.AppField name="job">{field => <field.TextField label="شغل" />}</form.AppField>

        <form.AppField name="phone">{field => <field.TextField label="شماره تلفن" />}</form.AppField>

        <div className="flex gap-1">
          <Link className={btn({ className: "flex-1", variant: "secondary" })} to="/forms/young-schema">
            <ArrowRightIcon />
            <span>قبلی</span>
          </Link>

          <form.SubmitBtn label="ادامه" className={btn({ className: "flex-2" })} afterChildren={<ArrowLeftIcon />} />
        </div>
      </form.AppForm>
    </Base>
  )
}
