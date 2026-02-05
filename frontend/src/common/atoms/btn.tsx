import type { ComponentProps } from "react"
import { tv, type VariantProps } from "tailwind-variants"

export const btn = tv({
  base: `
    flex items-center justify-center
    rounded-md border-none
    font-inherit cursor-pointer transition-all
    duration-100 shadow-md

    active:scale-95

    disabled:opacity-50
    disabled:scale-100
    disabled:duration-0
    disabled:cursor-not-allowed
  `,
  variants: {
    variant: {
      primary: `
        text-slate-100
        bg-blue-600
        hover:bg-blue-700
      `,
      secondary: `
        text-slate-800
        bg-slate-200
        hover:bg-slate-300
      `,
    },
    isIcon: {
      false: "gap-2 px-4 py-3 min-h-12",
      true: "gap-1 p-2 h-12 w-12",
    },
  },
  defaultVariants: {
    variant: "primary",
    isIcon: false,
  },
})

export type BtnProps = ComponentProps<"button"> & VariantProps<typeof btn> & {}

export function Btn({ className, isIcon, children, ...rest }: BtnProps) {
  return (
    <button type="button" className={btn({ className, isIcon })} {...rest}>
      {children}
    </button>
  )
}
