import { TanStackQueryProvider } from "#/common/lib/tanstack-query"
import type { PropsWithChildren } from "react"

export const Providers = ({ children }: PropsWithChildren) => <TanStackQueryProvider>{children}</TanStackQueryProvider>
