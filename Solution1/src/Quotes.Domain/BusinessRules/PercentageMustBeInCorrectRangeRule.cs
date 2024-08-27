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
        return percentage < 0 || percentage > 1;
    }

    public string Message => "The percentage must be in correct range";
}
