interface FieldStatusProps {
  isValid: boolean
  errors: Array<{ message: string }>
}

export function FieldStatus({ errors, isValid }: FieldStatusProps) {
  const errorMsgs = Array.from(new Set(errors.map(e => e.message)))

  return (
    <div className="flex text-sm">
      {!isValid && errors.length > 0 && (
        <ul className="text-red-500 list-disc list-inside">
          {errorMsgs.map((msg, i) => (
            <li key={i}>{msg}</li>
          ))}
        </ul>
      )}

      {isValid && <p className="text-green-600 font-medium">✅️ معتبر است</p>}
    </div>
  )
}
