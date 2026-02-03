using Backend.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Optional;

namespace Backend.Shared.Persistence;

public class SoftDeleteInterceptor : SaveChangesInterceptor {
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData      eventData,
        InterceptionResult<int> result
    ) {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries()) {
            if (entry.Entity is not Entity entity)
                continue;

            var now = DateTimeOffset.UtcNow;

            if (entry.State == EntityState.Added)
                entity.UpdateAuditFields(
                    deletedAt: Option.None<DateTimeOffset?>(),
                    updatedAt: Option.None<DateTimeOffset?>(),
                    createdAt: Option.Some(now)
                );

            if (entry.State == EntityState.Modified)
                entity.UpdateAuditFields(
                    deletedAt: Option.None<DateTimeOffset?>(),
                    updatedAt: Option.Some<DateTimeOffset?>(now),
                    createdAt: Option.None<DateTimeOffset>()
                );

            if (entry.State == EntityState.Deleted) {
                entry.State = EntityState.Modified;

                entity.UpdateAuditFields(
                    deletedAt: Option.Some<DateTimeOffset?>(DateTimeOffset.UtcNow),
                    updatedAt: Option.None<DateTimeOffset?>(),
                    createdAt: Option.None<DateTimeOffset>()
                );
            }
        }

        return result;
    }
}
