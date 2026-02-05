import type { ReactNode } from "react"
import { cn } from "tailwind-variants"

import { base } from "./base"

type MainProps = {
  children: ReactNode
  className?: string
}

export const Main = ({ className, children }: MainProps) => (
  <div className="flex flex-col w-full h-full">
    <Nav />

    <div className={base({ className: cn("py-8 w-full h-full", className) })}>{children}</div>
  </div>
)

const Nav = () => (
  <nav className="bg-slate-200 p-2">
    <img src="/Young.png" alt="" className="aspect-square w-12" />
  </nav>
)
