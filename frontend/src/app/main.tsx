import "./styles/main.css"

import { StrictMode } from "react"
import { createRoot } from "react-dom/client"

import { Providers } from "./providers"
import { Routes } from "./router/routes"

const container = document.getElementById("root")
if (container == null) throw new Error(`App container (#root) is null!`)
createRoot(container).render(
  <StrictMode>
    <Providers>
      <Routes />
    </Providers>
  </StrictMode>,
)
