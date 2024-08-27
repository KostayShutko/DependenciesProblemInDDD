using Quotes.Domain.BusinessRules;

namespace Quotes.Domain.Entities.ValueObjects;

public class Tax : ValueObject<decimal>
{
    public Tax(decimal tax)
        : base(tax)
    {
        BusinessRulesValidator.CheckRule(new PercentageMustBeInCorrectRangeRule(tax));
    }

    public static Tax Default => new Tax(1);
}