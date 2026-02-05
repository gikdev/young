import { createRouter, RouterProvider } from "@tanstack/react-router"

import { routeTree } from "./route-tree.gen"

export const router = createRouter({ routeTree })

// Register the router instance for type safety
declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router
  }
}

export const Routes = () => <RouterProvider router={router} />
