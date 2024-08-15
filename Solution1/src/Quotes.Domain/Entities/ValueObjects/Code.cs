namespace Quotes.Domain.Entities.ValueObjects;

public class Code : ValueObject<string>
{
    public Code(string code)
        : base(code)
    {
    }
}
