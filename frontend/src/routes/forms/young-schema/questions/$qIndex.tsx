import { Base } from "#/common/layouts/base"
import { createFileRoute, Navigate } from "@tanstack/react-router"

import { YsqQuestionsRepo } from "./-ysq-questions-repo"

export const Route = createFileRoute("/forms/young-schema/questions/$qIndex")({
  component: RouteComponent,
  params: {
    parse: raw => {
      const parsedQIndex = Number(raw.qIndex)
      const isQIndexNan = Number.isNaN(parsedQIndex)
      const qIndex = isQIndexNan ? 0 : parsedQIndex
      return { qIndex }
    },
  },
})

function RouteComponent() {
  const { qIndex } = Route.useParams()

  const question = YsqQuestionsRepo.getQuestionByIndex(qIndex)

  if (question == null) return <Navigate to="/forms/young-schema/basic-info" />

  return (
    <Base className="py-4 px-4 gap-4">
      <h1 className="font-bold text-slate-950 text-lg">
        {question.index}. {question.title}
      </h1>
    </Base>
  )
}
