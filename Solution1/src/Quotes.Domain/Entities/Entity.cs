using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.Entities;

public abstract class Entity : Entity<EntityId> { }

public abstract class Entity<TEntityId> 
    where TEntityId : EntityId
{
    public TEntityId Id { get; set; }

    public bool Equals(Entity<TEntityId> other)
    {
        if (other is null)
        {
            return false;
        }

        return Id.Equals(other.Id);
    }

    public virtual bool IsTransient()
    {
        return EqualityComparer<TEntityId>.Default.Equals(Id, default(TEntityId));
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(obj, null))
        {
            return false;
        }
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        for (var compareTo = obj as Entity<TEntityId>; compareTo != null;)
        {
            if (!IsTransient() && !compareTo.IsTransient() && EqualityComparer<TEntityId>.Default.Equals(Id, compareTo.Id))
            {
                return true;
            }
            return false;
        }

        for (var compareTo = obj as Entity<TEntityId>; compareTo != null; compareTo = null)
        {
            if (!IsTransient() && EqualityComparer<TEntityId>.Default.Equals(Id, compareTo.Id))
            {
                return true;
            }
        }

        return false;
    }

    public static bool operator ==(Entity<TEntityId> first, Entity<TEntityId> second)
    {
        if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
        {
            return true;
        }

        if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(Entity<TEntityId> first, Entity<TEntityId> second)
    {
        return !(first == second);
    }
}