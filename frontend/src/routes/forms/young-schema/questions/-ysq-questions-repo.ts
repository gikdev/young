import questions from "./ysq-questions.json"

type QuestionPlace = "last" | "first" | "middle"

interface Question {
  index: number
  title: string
  place: QuestionPlace
  tag?: string
}

export class YsqQuestionsRepo {
  public static getQuestionByIndex(qIndex: number): Question | null {
    const idx = questions.findIndex(q => q.index === qIndex)
    if (idx === -1) return null

    const question = questions[idx]

    return {
      index: qIndex,
      title: question.question,
      place: YsqQuestionsRepo.calculateQuestionPlace(qIndex, questions.length),
      tag: question.tag
    }
  }

  private static calculateQuestionPlace(qIndex: number, questionsCount: number): QuestionPlace {
    let place: QuestionPlace = "middle"

    if (qIndex === 1) {
      place = "first"
    }

    if (qIndex === questionsCount) {
      place = "last"
    }

    return place
  }
}
