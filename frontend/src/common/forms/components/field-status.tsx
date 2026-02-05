interface FieldStatusProps {
  isValid: boolean
  isDirty: boolean
  errors: Array<{ message: string }>
}

export function FieldStatus({ errors, isValid, isDirty }: FieldStatusProps) {
  if (!isDirty) return null

  return (
    <div className="flex text-sm">
      {!isValid && errors.length > 0 && (
        <ul className="text-red-500 list-disc list-inside">
          {errors.map((err, i) => (
            <li key={i}>{err.message}</li>
          ))}
        </ul>
      )}

      {isValid && <p className="text-green-600 font-medium">✅️ معتبر است</p>}
    </div>
  )
}
