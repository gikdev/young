import { createFileRoute, Navigate } from "@tanstack/react-router"

export const Route = createFileRoute("/l/fysq")({
  component: () => <Navigate to="/forms/young-schema" />,
})
