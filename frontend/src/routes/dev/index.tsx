import { Base } from "#/common/layouts/base"
import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute("/dev/")({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <Base dir="ltr">
      <p>خالی...</p>
    </Base>
  )
}
