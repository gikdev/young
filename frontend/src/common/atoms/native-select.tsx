import type { ComponentProps } from "react"
import { tv } from "tailwind-variants"

export const nativeSelect = tv({
  base: `
    w-full min-w-0
    py-2 px-3
    rounded-md
    min-h-12

    border-2
    border-slate-400
    bg-transparent
    disabled:bg-black/20

    text-base
    placeholder:text-slate-500

    select-none
    transition-colors
    focus:border-blue-500
    outline-none

    disabled:opacity-50
    disabled:pointer-events-none
    disabled:cursor-not-allowed
  `,
})

type NativeSelectProps = ComponentProps<"select">

export const NativeSelect = ({ className, ...props }: NativeSelectProps) => (
  <select dir="auto" className={nativeSelect({ className })} {...props} />
)
