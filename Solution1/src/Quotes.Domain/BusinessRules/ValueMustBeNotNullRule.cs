namespace Quotes.Domain.BusinessRules;

public class ValueMustBeNotNullRule : IBusinessRule
{
    private readonly object value;

    public ValueMustBeNotNullRule(object value)
    {
        this.value = value;
    }

    public bool IsBroken()
    {
        return value is null;
    }

    public string Message => "The value must be set";
}