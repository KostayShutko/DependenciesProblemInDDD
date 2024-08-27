namespace Quotes.Domain.BusinessRules;

public class CostMustBeGreaterThanZeroRule : IBusinessRule
{
    private readonly decimal cost;

    public CostMustBeGreaterThanZeroRule(decimal cost)
    {
        this.cost = cost;
    }

    public bool IsBroken()
    {
        var isValid = cost > 0;
        return !isValid;
    }

    public string Message => "The cost must be greater than zero";
}
