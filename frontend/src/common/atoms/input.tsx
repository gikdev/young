import type { ComponentProps } from "react"
import { tv } from "tailwind-variants"

export const input = tv({
  base: `
    w-full min-w-0 rounded-md px-3 py-2
    outline-none border-2 border-slate-400
    min-h-12

    text-base md:text-sm
    placeholder:text-slate-600

    bg-transparent
    disabled:bg-black/20

    focus:border-blue-500

    transition-colors
    disabled:pointer-events-none
    disabled:cursor-not-allowed
    disabled:opacity-50
  `,
})

export const Input = ({ className, ...props }: ComponentProps<"input">) => (
  <input dir="auto" className={input({ className })} {...props} />
)
