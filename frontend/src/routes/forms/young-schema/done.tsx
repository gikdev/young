import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute("/forms/young-schema/done")({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/forms/young-schema/done"!</div>
}
