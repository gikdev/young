import { Base } from "#/common/layouts/base"
import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute("/")({
  component: Index,
})

function Index() {
  return (
    <Base>
      <p>- خالی -</p>
    </Base>
  )
}
