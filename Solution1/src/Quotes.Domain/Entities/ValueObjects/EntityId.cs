namespace Quotes.Domain.Entities.ValueObjects;

public class EntityId : ValueObject<Guid>
{
    public EntityId()
    {
    }

    public EntityId(Guid entityId)
        : base(entityId)
    {
    }

    public static EntityId New => new EntityId(Guid.NewGuid());
}
