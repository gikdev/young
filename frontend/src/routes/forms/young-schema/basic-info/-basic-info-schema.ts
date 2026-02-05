import * as v from "valibot"

export const BasicInfoSchema = v.object({
  fullName: v.pipe(v.string(), v.trim(), v.minLength(3, "نام باید حداقل ۳ کاراکتر باشد")),
  age: v.pipe(v.number(), v.minValue(1, "سن معتبر نیست"), v.maxValue(200, "سن معتبر نیست")),
  degree: v.pipe(v.string(), v.trim(), v.minLength(1, "مدرک تحصیلی خود را وارد کنید")),
  major: v.pipe(v.string(), v.trim(), v.minLength(1, "مدرک تحصیلی خود را وارد کنید")),
  job: v.pipe(v.string(), v.trim(), v.minLength(1, "مدرک تحصیلی خود را وارد کنید")),
  gender: v.picklist(["male", "female"], "جنسیت را انتخاب کنید"),
  phone: v.pipe(v.string(), v.regex(/^09\d{9}$/, "شماره تلفن معتبر نیست (اعداد باید انگلیسی باشند)")),
})

export type BasicInfoFormValues = v.InferInput<typeof BasicInfoSchema>
