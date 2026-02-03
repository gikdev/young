using Backend.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Shared.Persistence;

public abstract class EntityBaseConfig<TEntity>
    : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity {
    public virtual void Configure(EntityTypeBuilder<TEntity> builder) {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.CreatedAt).ValueGeneratedNever();
        builder.Property(x => x.UpdatedAt).ValueGeneratedNever();
        builder.Property(x => x.DeletedAt).ValueGeneratedNever();

        builder.Property(x => x.CreatedAt).Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}
