import DateObject from "react-date-object"
import gregorian from "react-date-object/calendars/gregorian"
import persian from "react-date-object/calendars/persian"
import gregorian_en from "react-date-object/locales/gregorian_en"
import persian_fa from "react-date-object/locales/persian_fa"

export class DateObjectUtils {
  private constructor() {}

  public static toDateObject = (utcIso: string) => new DateObject({ date: utcIso, calendar: gregorian })

  public static toGregorianEnglish = (date: DateObject) =>
    new DateObject({ date }).convert(gregorian).setLocale(gregorian_en)

  public static toPersianFarsi = (date: DateObject) => new DateObject({ date }).convert(persian).setLocale(persian_fa)

  public static toUtcIso = (date: DateObject) => DateObjectUtils.toGregorianEnglish(date).toDate().toISOString()
}
