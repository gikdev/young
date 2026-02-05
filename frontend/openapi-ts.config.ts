import { defineConfig } from "@hey-api/openapi-ts"

export default defineConfig({
  input: "http://localhost:5888/openapi/v1.json",
  output: {
    path: "src/common/api/generated/client",
  },
  plugins: [
    { name: "@hey-api/client-axios", baseUrl: "/", exportFromIndex: true },
    { name: "@hey-api/typescript", enums: "javascript" },
    { name: "@hey-api/sdk", asClass: false, transformer: false },
    { name: "@tanstack/react-query", exportFromIndex: true },
  ],
})
