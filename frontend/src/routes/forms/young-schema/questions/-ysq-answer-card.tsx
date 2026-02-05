import { btn } from "#/common/atoms/btn"
import { useAppDispatch } from "#/common/store"
import { type Icon } from "@phosphor-icons/react"

import { youngSchemaFormSlice } from "../-store"

interface YsqAnswerCardProps {
  selectedAnswer: number | null
  qIndex: number
  value: 1 | 2 | 3 | 4 | 5 | 6
  title: string
  Icon: Icon
}

export function YsqAnswerCard({ selectedAnswer, qIndex, value, title, Icon }: YsqAnswerCardProps) {
  const dispatch = useAppDispatch()

  return (
    <button
      className={btn({ variant: selectedAnswer === value ? "primary" : "secondary" })}
      onClick={() => dispatch(youngSchemaFormSlice.actions.setAnswer({ questionIndex: qIndex, value: value }))}
    >
      <Icon size={24} weight={selectedAnswer === value ? "fill" : "regular"} />
      <span>{title}</span>
    </button>
  )
}
