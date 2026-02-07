import { createSession, listYsqFormsOptions } from "#/common/api/generated/client"
import { btn } from "#/common/atoms/btn"
import { Base } from "#/common/layouts/base"
import { HouseIcon } from "@phosphor-icons/react"
import { useQuery } from "@tanstack/react-query"
import { createFileRoute, Link, redirect } from "@tanstack/react-router"
import { useState } from "react"

export const Route = createFileRoute("/admin/entries/")({
  component: RouteComponent,
  beforeLoad,
})

async function beforeLoad() {
  const isAdmin = Boolean(sessionStorage.getItem("IS_ADMIN"))
  if (isAdmin) return

  const passcode = window.prompt("رمز:")
  if (!passcode || !passcode.length) throw redirect({ to: "/" })

  const result = await createSession({ body: { passcode } })
  if (result.status === 204) {
    sessionStorage.setItem("IS_ADMIN", String(true))
    return
  }

  alert("مشکلی پیش آمده... (یا رمز اشتباه هست)")
  throw redirect({ to: "/" })
}

function RouteComponent() {
  const { data } = useQuery(listYsqFormsOptions())
  const [filter, setFilter] = useState("")

  const filteredItems = data?.items.filter(
    entry => entry.fullName.toLowerCase().includes(filter.toLowerCase()) || entry.phone.includes(filter),
  )

  return (
    <Base className="items-center py-4 px-4 text-center gap-4">
      <div className="mb-4 flex gap-1 items-center">
        <Link to="/" className={btn({ variant: "secondary" })}>
          <HouseIcon mirrored size={32} />
          <h1 className="font-bold text-slate-950 text-2xl">فرم‌های ارسال‌شده</h1>
        </Link>
      </div>

      <input
        type="text"
        placeholder="جستجو بر اساس نام یا تلفن..."
        value={filter}
        onChange={e => setFilter(e.target.value)}
        className="mb-4 px-3 py-2 border border-slate-300 rounded w-full max-w-sm text-slate-900"
      />

      <div className="overflow-x-auto w-full">
        <table className="min-w-max w-full border-collapse border border-slate-300">
          <thead>
            <tr className="bg-slate-100">
              <th className="border border-slate-300 px-4 py-2 text-start">نام</th>
              <th className="border border-slate-300 px-4 py-2 text-center">تلفن</th>
              <th className="border border-slate-300 px-4 py-2">مشاهده</th>
            </tr>
          </thead>
          <tbody>
            {filteredItems?.map(entry => (
              <tr key={entry.id} className="hover:bg-slate-50">
                <td className="border border-slate-300 px-4 py-2 text-start">{entry.fullName}</td>
                <td className="border border-slate-300 px-4 py-2 text-center">{entry.phone}</td>
                <td className="border border-slate-300 px-4 py-2">
                  <Link
                    className={btn({ variant: "secondary" })}
                    to="/admin/entries/$entryId"
                    params={{ entryId: entry.id }}
                  >
                    مشاهده
                  </Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </Base>
  )
}
