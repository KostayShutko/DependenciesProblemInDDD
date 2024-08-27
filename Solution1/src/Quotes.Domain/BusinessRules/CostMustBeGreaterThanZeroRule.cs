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
        return cost < 0;
    }

    public string Message => "The cost must be greater or equal to zero";
}
