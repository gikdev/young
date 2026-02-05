import { btn } from "#/common/atoms/btn"
import { Base } from "#/common/layouts/base"
import { useAppSelector } from "#/common/store"
import {
  ArrowLeftIcon,
  ArrowRightIcon,
  CheckCircleIcon,
  CheckIcon,
  TargetIcon,
  WarningIcon,
  XCircleIcon,
  XIcon,
} from "@phosphor-icons/react"
import { createFileRoute, Link, linkOptions, Navigate, useNavigate } from "@tanstack/react-router"

import { YsqAnswerCard } from "./-ysq-answer-card"
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
  const navigate = useNavigate()
  const { qIndex } = Route.useParams()

  const question = YsqQuestionsRepo.getQuestionByIndex(qIndex)
  const isQuestionFirst = question?.place === "first"
  const isQuestionLast = question?.place === "last"
  const questionIdx = question?.index ?? 0

  const answer = useAppSelector(s => s.forms.youngSchemaForm.answers.find(a => a.questionIndex === qIndex))
  const selectedAnswer = answer?.value
  const isAnythingSelected = !!answer?.value

  const prevLink = isQuestionFirst
    ? linkOptions({
        to: "/forms/young-schema/basic-info",
      })
    : linkOptions({
        to: "/forms/young-schema/questions/$qIndex",
        params: { qIndex: questionIdx - 1 },
      })

  const nextLink = isQuestionLast
    ? linkOptions({
        to: "/forms/young-schema/done",
      })
    : linkOptions({
        to: "/forms/young-schema/questions/$qIndex",
        params: { qIndex: questionIdx + 1 },
      })

  const handleOnAnswerClick = () => {
    if (question == null) return

    setTimeout(() => {
      navigate(nextLink)
    }, 200)
  }

  if (question == null) return <Navigate to="/forms/young-schema/basic-info" />

  return (
    <Base className="py-4 px-4 gap-4 justify-between">
      <h1 className="font-bold text-slate-950 text-lg">
        {question.index}. {question.title}
      </h1>

      <div className="grid gap-4 grid-cols-[repeat(auto-fit,minmax(160px,1fr))] sm:grid-cols-3">
        <YsqAnswerCard
          additionalOnClick={handleOnAnswerClick}
          Icon={WarningIcon}
          value={1}
          qIndex={qIndex}
          selectedAnswer={selectedAnswer || null}
          title="کاملا غلط"
        />

        <YsqAnswerCard
          additionalOnClick={handleOnAnswerClick}
          Icon={XCircleIcon}
          value={2}
          qIndex={qIndex}
          selectedAnswer={selectedAnswer || null}
          title="تقریبا غلط"
        />

        <YsqAnswerCard
          additionalOnClick={handleOnAnswerClick}
          Icon={XIcon}
          value={3}
          qIndex={qIndex}
          selectedAnswer={selectedAnswer || null}
          title="اندکی غلط"
        />

        <YsqAnswerCard
          additionalOnClick={handleOnAnswerClick}
          Icon={CheckIcon}
          value={4}
          qIndex={qIndex}
          selectedAnswer={selectedAnswer || null}
          title="اندکی درست"
        />

        <YsqAnswerCard
          additionalOnClick={handleOnAnswerClick}
          Icon={CheckCircleIcon}
          value={5}
          qIndex={qIndex}
          selectedAnswer={selectedAnswer || null}
          title="تقریبا درست"
        />

        <YsqAnswerCard
          additionalOnClick={handleOnAnswerClick}
          Icon={TargetIcon}
          value={6}
          qIndex={qIndex}
          selectedAnswer={selectedAnswer || null}
          title="کاملا درست"
        />
      </div>

      <div className="flex gap-1">
        <Link className={btn({ className: "flex-1", variant: "secondary" })} {...prevLink}>
          <ArrowRightIcon />
          <span>قبلی</span>
        </Link>

        <Link
          className={btn({ className: "flex-2", variant: isAnythingSelected ? "primary" : "disabled" })}
          disabled={!isAnythingSelected}
          {...nextLink}
        >
          <span>{isQuestionLast ? "اتمام" : "بعدی"}</span>
          {isQuestionLast ? <CheckIcon /> : <ArrowLeftIcon />}
        </Link>
      </div>
    </Base>
  )
}
