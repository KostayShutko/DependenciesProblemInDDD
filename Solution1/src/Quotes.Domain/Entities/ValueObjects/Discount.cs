using Quotes.Domain.BusinessRules;

namespace Quotes.Domain.Entities.ValueObjects;

public class Discount : ValueObject<decimal>
{
    public Discount(decimal discount) 
        : base(discount) 
    {
        BusinessRulesValidator.CheckRule(new PercentageMustBeInCorrectRangeRule(discount));
    }

    public static Discount Default => new Discount(1);
}