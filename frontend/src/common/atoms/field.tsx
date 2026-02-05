/** biome-ignore-all lint/a11y/noLabelWithoutControl: 🙃 */
import type { ReactNode } from "react"
import { tv } from "tailwind-variants"

export const field = tv({
  slots: {
    container: `flex flex-col gap-1`,
    label: ``,
  },
})

interface FieldProps {
  title: string
  children: ReactNode
}

const { container, label } = field()

export const Field = ({ title, children }: FieldProps) => (
  <div className={container()}>
    <p dir="auto" className={label()}>
      {title}:
    </p>
    {children}
  </div>
)

export const FieldLabel = ({ title, children }: FieldProps) => (
  <label className={container()}>
    <p dir="auto" className={label()}>
      {title}:
    </p>
    {children}
  </label>
)
