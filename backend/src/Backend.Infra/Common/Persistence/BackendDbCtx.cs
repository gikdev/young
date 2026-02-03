using System.Reflection;
using Backend.Domain.YsqFormAggregate;
using Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Common.Persistence;

public class BackendDbCtx(DbContextOptions<BackendDbCtx> options) : BaseDbCtx(options) {
    public DbSet<YsqForm> YsqForms => Set<YsqForm>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
