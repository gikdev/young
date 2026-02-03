using Microsoft.EntityFrameworkCore;
using SmartEnum.EFCore;

namespace Backend.Shared.Persistence;

public abstract class BaseDbCtx(DbContextOptions options) : DbContext(options) {
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        configurationBuilder.ConfigureSmartEnum();

        base.ConfigureConventions(configurationBuilder);
    }
}
