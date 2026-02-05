import { createYsqFormMutation, YsqResponse, type YsqFormAnswerRequest } from "#/common/api/generated/client"
import { Btn } from "#/common/atoms/btn"
import { Base } from "#/common/layouts/base"
import { useAppSelector } from "#/common/store"
import { FloppyDiskIcon } from "@phosphor-icons/react"
import { useMutation } from "@tanstack/react-query"
import { createFileRoute, Navigate } from "@tanstack/react-router"
import { useCallback } from "react"

import { title, resultError, resultPending, resultSuccess } from "./content.json"

export const Route = createFileRoute("/forms/young-schema/done")({
  component: RouteComponent,
})

function RouteComponent() {
  const formResult = useAppSelector(s => s.forms.youngSchemaForm)
  const mutation = useMutation(createYsqFormMutation())

  const send = useCallback(() => {
    const mapToEnum = (answerValue: number): YsqResponse => {
      switch (answerValue) {
        case 1:
          return YsqResponse.COMPLETELY_FALSE
        case 2:
          return YsqResponse.MOSTLY_FALSE
        case 3:
          return YsqResponse.SLIGHTLY_FALSE
        case 4:
          return YsqResponse.SLIGHTLY_TRUE
        case 5:
          return YsqResponse.MOSTLY_TRUE
        case 6:
          return YsqResponse.COMPLETELY_TRUE
        default:
          throw new Error("INVALID ANSWER VALUE!")
      }
    }

    const answers: YsqFormAnswerRequest[] = formResult.answers.map(a => ({
      questionIndex: a.questionIndex,
      ysqResponse: mapToEnum(a.value),
    }))

    mutation.mutate({
      body: {
        age: formResult.basicInfo.age,
        answers,
        degree: formResult.basicInfo.degree,
        educationMajor: formResult.basicInfo.major,
        fullName: formResult.basicInfo.fullName,
        gender: formResult.basicInfo.gender,
        jobTitle: formResult.basicInfo.job,
        phone: formResult.basicInfo.phone,
      },
    })
  }, [formResult, mutation])

  if (formResult.answers.length <= 0) return <Navigate to="/forms/young-schema" />

  return (
    <Base className="items-center py-4 px-4 text-center gap-4">
      <img src="/thinking.jpg" alt="" className="border-2 border-slate-300 rounded-md max-w-64 w-full" />

      <h1 className="font-bold text-slate-950 text-2xl">{title}</h1>

      {mutation.isIdle && (
        <div className="flex flex-col gap-1">
          <Btn onClick={send} variant="primary">
            <FloppyDiskIcon size={20} />
            <span>ارسال و ذخیره نتیجه</span>
          </Btn>
        </div>
      )}
      {mutation.isPending && <p>{resultPending}</p>}
      {mutation.isSuccess && <p>{resultSuccess}</p>}
      {mutation.isError && (
        <div className="flex flex-col gap-1">
          <p>{resultError}</p>

          <p>
            <code>{mutation.error instanceof Error ? mutation.error.message : String(mutation.error)}</code>
          </p>

          <Btn onClick={send} variant="secondary">
            تلاش دوباره
          </Btn>
        </div>
      )}
    </Base>
  )
}
