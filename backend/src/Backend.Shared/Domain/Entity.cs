using Optional;

namespace Backend.Shared.Domain;

public abstract class Entity {
    protected Entity(Guid? id = null) {
        Id = id ?? Guid.NewGuid();
    }

    protected Entity() { }

    public Guid            Id        { get; }
    public DateTimeOffset  CreatedAt { get; internal set; }
    public DateTimeOffset? UpdatedAt { get; internal set; }
    public DateTimeOffset? DeletedAt { get; internal set; }

    public bool IsDeleted => DeletedAt.HasValue;

    public void UpdateAuditFields(
        Option<DateTimeOffset>  createdAt,
        Option<DateTimeOffset?> updatedAt,
        Option<DateTimeOffset?> deletedAt
    ) {
        createdAt.MatchSome(v => CreatedAt = v);
        updatedAt.MatchSome(v => UpdatedAt = v);
        deletedAt.MatchSome(v => DeletedAt = v);
    }

    public override bool Equals(object? obj) {
        if (obj is null || obj.GetType() != GetType()) return false;

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }
}
