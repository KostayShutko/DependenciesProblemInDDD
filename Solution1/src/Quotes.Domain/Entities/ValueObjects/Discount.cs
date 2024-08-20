namespace Quotes.Domain.Entities.ValueObjects;

public class Discount : ValueObject<decimal>
{
    public Discount(decimal discount) 
        : base(discount) 
    {
    }

    public static Discount Default => new Discount(1);
}