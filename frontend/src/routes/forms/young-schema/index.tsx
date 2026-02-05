import { btn } from "#/common/atoms/btn"
import { Base } from "#/common/layouts/base"
import { ArrowLeftIcon } from "@phosphor-icons/react"
import { createFileRoute, Link } from "@tanstack/react-router"

import { title, introduction, description } from "./content.json"

export const Route = createFileRoute("/forms/young-schema/")({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <Base className="items-center py-4 px-4 text-center gap-4">
      <img src="/thinking.jpg" alt="" className="border-2 border-slate-300 rounded-md max-w-64 w-full" />

      <h1 className="font-bold text-slate-950 text-2xl">{title}</h1>

      <p>{introduction}</p>

      <p>{description}</p>

      <Link className={btn({ className: "w-full" })} to="/forms/young-schema/basic-info">
        <span>شروع</span>
        <ArrowLeftIcon />
      </Link>
    </Base>
  )
}
