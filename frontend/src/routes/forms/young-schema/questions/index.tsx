import { createFileRoute, Navigate } from "@tanstack/react-router"

export const Route = createFileRoute("/forms/young-schema/questions/")({
  component: () => <Navigate to="/forms/young-schema" />,
})
