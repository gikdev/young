import { FieldLabel } from "#/common/atoms/field"
import { NativeSelect } from "#/common/atoms/native-select"

import { useFieldContext } from "../contexts"

import { FieldStatus } from "./field-status"

type Option = {
  value: string
  label: string
}

type Props = {
  label: string
  options: Option[]
}

export function NativeSelectField({ label, options }: Props) {
  const field = useFieldContext<string>()

  return (
    <FieldLabel title={label}>
      <NativeSelect value={field.state.value ?? ""} onChange={e => field.handleChange(e.target.value)}>
        <option value="">انتخاب کنید</option>

        {options.map(opt => (
          <option key={opt.value} value={opt.value}>
            {opt.label}
          </option>
        ))}
      </NativeSelect>
      <FieldStatus
        errors={field.state.meta.errors}
        isDirty={field.state.meta.isDirty}
        isValid={field.state.meta.isValid}
      />
    </FieldLabel>
  )
}
