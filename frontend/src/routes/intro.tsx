import { Base } from "#/common/layouts/base"
import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute("/intro")({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <Base>
      <p>- خالی -</p>
    </Base>
  )
}
