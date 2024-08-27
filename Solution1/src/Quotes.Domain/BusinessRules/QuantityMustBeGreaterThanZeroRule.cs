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
        var isValid = quantity > 0;
        return !isValid;
    }

    public string Message => "The quantity must be greater than zero";
}
