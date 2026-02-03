using Backend.Domain.YsqFormAggregate;
using Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.YsqForms.Persistence;

public class YsqFormConfigs : EntityBaseConfig<YsqForm> {
    public override void Configure(EntityTypeBuilder<YsqForm> builder) {
        base.Configure(builder);

        builder.OwnsMany(x => x.Answers);
    }
}
