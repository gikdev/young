import { createFormHook } from "@tanstack/react-form"

import { NativeSelectField } from "./components/native-select-field"
import { NumberField } from "./components/number-field"
import { SubmitBtn } from "./components/submit-btn"
import { TextField } from "./components/text-field"
import { fieldContext, formContext } from "./contexts"

export const { useAppForm } = createFormHook({
  fieldComponents: {
    TextField,
    NumberField,
    NativeSelectField,
  },
  formComponents: {
    SubmitBtn,
  },
  fieldContext,
  formContext,
})
