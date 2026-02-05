import { TanStackQueryProvider } from "#/common/lib/tanstack-query"
import { AppStoreProvider } from "#/common/store"
import type { PropsWithChildren } from "react"

export const Providers = ({ children }: PropsWithChildren) => (
  <AppStoreProvider>
    <TanStackQueryProvider>{children}</TanStackQueryProvider>
  </AppStoreProvider>
)
