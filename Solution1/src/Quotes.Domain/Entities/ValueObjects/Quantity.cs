using Quotes.Domain.BusinessRules;

namespace Quotes.Domain.Entities.ValueObjects;

public class Quantity : ValueObject<int>
{
    public Quantity(int quantity)
        : base(quantity)
    {
        BusinessRulesValidator.CheckRule(new QuantityMustBeGreaterThanZeroRule(quantity));
    }
}
