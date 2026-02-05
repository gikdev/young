import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute("/forms/young-schema/questions/$qIndex")({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/forms/young-schema/questions/$index"!</div>
}
