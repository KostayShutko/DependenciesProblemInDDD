namespace Quotes.Domain.BusinessRules;

public class QuantityMustBeGreaterThanZeroRule : IBusinessRule
{
    private readonly int quantity;

    public QuantityMustBeGreaterThanZeroRule(int quantity)
    {
        this.quantity = quantity;
    }

    public bool IsBroken()
    {
        return quantity < 0;
    }

    public string Message => "The quantity must be greater or equal to zero";
}
