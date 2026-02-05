import tailwindcss from "@tailwindcss/vite"
import { tanstackRouter } from "@tanstack/router-plugin/vite"
import react from "@vitejs/plugin-react"
import { defineConfig, type PluginOption, type UserConfig } from "vite"
import tsconfigPaths from "vite-tsconfig-paths"

const reactPlugin = react({
  babel: {
    plugins: [["babel-plugin-react-compiler"]],
  },
})

const tanstackRouterPlugin = tanstackRouter({
  target: "react",
  autoCodeSplitting: false,
  semicolons: false,
  quoteStyle: "double",
  generatedRouteTree: "./src/app/router/route-tree.gen.ts",
})

const plugins: PluginOption[] = [
  tanstackRouterPlugin,
  reactPlugin,
  tailwindcss(),
  tsconfigPaths(),
  null,
  null,
  null,
  null,
]

const server: UserConfig["server"] = {
  port: 4888,
  proxy: {
    "/api": {
      target: "http://localhost:5888",
      changeOrigin: true,
      secure: false,
    },
  },
}

export default defineConfig({
  plugins,
  server,
})
