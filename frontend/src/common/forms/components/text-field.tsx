import { FieldLabel } from "#/common/atoms/field"
import { Input } from "#/common/atoms/input"

import { useFieldContext } from "../contexts"

import { FieldStatus } from "./field-status"

export function TextField({ label }: { label: string }) {
  const field = useFieldContext<string>()

  return (
    <FieldLabel title={label}>
      <Input value={field.state.value} onChange={e => field.handleChange(e.target.value)} />
      <FieldStatus errors={field.state.meta.errors} isValid={field.state.meta.isValid} />
    </FieldLabel>
  )
}
