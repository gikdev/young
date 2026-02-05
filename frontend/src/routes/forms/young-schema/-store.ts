import type { PleaseShutUpTypeScript_IKnowWhatIAmDoing } from "#/common/types/shut-up"
import { createSlice, type PayloadAction } from "@reduxjs/toolkit"

interface BasicInfoFormValues {
  fullName: string
  age: number
  gender: "male" | "female"
  degree: string
  major: string
  job: string
  phone: string
}

interface Answer {
  questionIndex: number
  value: number
}

export interface YoungSchemaFormState {
  basicInfo: BasicInfoFormValues
  answers: Answer[]
}

const initialState: YoungSchemaFormState = {
  basicInfo: {
    fullName: "",
    age: 0,
    gender: "" as PleaseShutUpTypeScript_IKnowWhatIAmDoing,
    degree: "",
    major: "",
    job: "",
    phone: "",
  },
  answers: [],
}

export const youngSchemaFormSlice = createSlice({
  name: "YoungSchemaForm",
  initialState,
  reducers: {
    setBasicInfo(state, action: PayloadAction<Partial<BasicInfoFormValues>>) {
      state.basicInfo = { ...state.basicInfo, ...action.payload }
    },

    setAnswer(state, action: PayloadAction<Answer>) {
      const idx = state.answers.findIndex(a => a.questionIndex === action.payload.questionIndex)

      if (idx === -1) {
        state.answers.push(action.payload)
        return
      }

      state.answers[idx].value = action.payload.value
    },

    clearForm(state) {
      state.basicInfo = initialState.basicInfo
      state.answers = []
    },
  },
})
