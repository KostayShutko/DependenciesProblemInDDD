using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules;

public class QuoteNameMustBeUniqueRule : IAsyncBusinessRule, IHasCheck
{
    private IIsQuoteNameUniqueCheck check;
    private readonly Title name;

    public QuoteNameMustBeUniqueRule(Title name)
    {
        this.name = name;
    }

    public void UseCheck(ICheck check)
    {
        this.check = (IIsQuoteNameUniqueCheck)check;
    }

    public Type CheckType => typeof(IIsQuoteNameUniqueCheck);

    public async Task<bool> IsBroken()
    {
        var result = await check.Execute(name);
        return result.IsFailed;
    }

    public string Message => "Quote name must be unique";
}
