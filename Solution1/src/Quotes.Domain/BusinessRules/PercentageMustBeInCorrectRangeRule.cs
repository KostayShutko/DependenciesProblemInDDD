using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules;

public class PercentageMustBeInCorrectRangeRule : IBusinessRule
{
    private readonly decimal percentage;

    public PercentageMustBeInCorrectRangeRule(decimal percentage)
    {
        this.percentage = percentage;
    }

    public bool IsBroken()
    {
        var isValid = percentage > 0 && percentage <= 1;
        return !isValid;
    }

    public string Message => "The percentage must be in correct range";
}
