namespace Backend.Shared.Domain;

public abstract class AggregateRoot : Entity {
    protected AggregateRoot(Guid? id = null) : base(id) { }

    protected AggregateRoot() { }
}
