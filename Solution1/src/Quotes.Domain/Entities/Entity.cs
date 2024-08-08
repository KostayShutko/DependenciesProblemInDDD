namespace Quotes.Domain.Entities;

public abstract class Entity
{
    public int Id { get; set; }

    public bool IsNew() => Id == 0;
}