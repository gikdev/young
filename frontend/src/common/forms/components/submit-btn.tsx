import type { ReactNode } from "react"

import { useFormContext } from "../contexts"

interface SubmitBtnProps {
  label: string
  className?: string
  beforeChildren?: ReactNode
  afterChildren?: ReactNode
}

export function SubmitBtn({ label, className, afterChildren, beforeChildren }: SubmitBtnProps) {
  const form = useFormContext()

  return (
    <form.Subscribe selector={state => [state.isSubmitting, state.canSubmit, state.isFormValid]}>
      {([isSubmitting, canSubmit, isFormValid]) => (
        <button
          type="submit"
          disabled={isSubmitting || !canSubmit || !isFormValid}
          className={className}
          onClick={() => form.handleSubmit()}
        >
          {beforeChildren}
          <span>{label}</span>
          {afterChildren}
        </button>
      )}
    </form.Subscribe>
  )
}
