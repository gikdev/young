import { listYsqFormsOptions } from "#/common/api/generated/client"
import { btn } from "#/common/atoms/btn"
import { Base } from "#/common/layouts/base"
import { useQuery } from "@tanstack/react-query"
import { createFileRoute, Link } from "@tanstack/react-router"

export const Route = createFileRoute("/admin/entries/")({
  component: RouteComponent,
})

function RouteComponent() {
  const { data } = useQuery(listYsqFormsOptions())

  return (
    <Base className="items-center py-4 px-4 text-center gap-4">
      <h1 className="font-bold text-slate-950 text-2xl">فرم‌های ارسال‌شده</h1>

      {/* {data?.items.map(entry => ())} */}
      <div className="overflow-x-auto max-w-full">
        <div className="grid gap-4 border-2 border-slate-300 grid-cols-3 p-4 rounded-lg min-w-max">
          <p className="font-bold pb-2 border-b-2 border-slate-300 text-slate-900">نام</p>
          <p className="font-bold pb-2 border-b-2 border-slate-300 text-slate-900">تلفن</p>
          <p className="font-bold pb-2 border-b-2 border-slate-300 text-slate-900">مشاهده</p>

          {data?.items.map(entry => (
            <>
              <p key={entry.id} className="font-bold text-slate-900">
                {entry.fullName}
              </p>

              <p key={entry.id} className="">
                {entry.phone}
              </p>

              <Link
                key={entry.id}
                className={btn({ variant: "secondary" })}
                to="/admin/entries/$entryId"
                params={{ entryId: entry.id }}
              >
                مشاهده
              </Link>
            </>
          ))}
        </div>
      </div>
    </Base>
  )
}
