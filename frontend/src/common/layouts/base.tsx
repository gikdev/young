import type { ComponentProps } from "react"
import { tv } from "tailwind-variants"

export const base = tv({
  base: `
    px-4 sm:px-6 lg:px-8
    max-w-7xl mx-auto
    min-h-screen flex flex-col
  `,
})

type BaseProps = ComponentProps<"div"> & {}

export const Base = ({ className, ...rest }: BaseProps) => <div className={base({ className })} {...rest} />
