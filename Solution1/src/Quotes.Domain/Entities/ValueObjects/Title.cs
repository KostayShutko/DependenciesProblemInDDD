namespace Quotes.Domain.Entities.ValueObjects;

public class Title : ValueObject<string>
{
    public Title(string title)
        : base(title)
    {
    }
}
