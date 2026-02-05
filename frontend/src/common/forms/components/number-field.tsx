import { FieldLabel } from "#/common/atoms/field"
import { Input } from "#/common/atoms/input"
import type { ChangeEvent } from "react"

import { useFieldContext } from "../contexts"

import { FieldStatus } from "./field-status"

export function NumberField({ label }: { label: string }) {
  const field = useFieldContext<number>()

  const onChange = (e: ChangeEvent<HTMLInputElement, HTMLInputElement>) => {
    const parsed = Number(e.target.value)
    const isNan = Number.isNaN(parsed)
    const result = isNan ? 0 : parsed
    field.setValue(result)
  }

  return (
    <FieldLabel title={label}>
      <Input type="number" value={field.state.value} onChange={onChange} />
      <FieldStatus errors={field.state.meta.errors} isValid={field.state.meta.isValid} />
    </FieldLabel>
  )
}
