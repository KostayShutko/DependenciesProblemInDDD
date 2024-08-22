using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules;

public class QuoteNameMustBeUniqueRule : IAsyncBusinessRule
{
    private readonly Title name;

    public ICheck Check { get; set; }

    public QuoteNameMustBeUniqueRule(Title name)
    {
        this.name = name;
    }

    public async Task<bool> IsBroken()
    {
        var isQuoteNameUniqueCheck = (IIsQuoteNameUniqueCheck)Check;
        var isQuoteNameUnique = await isQuoteNameUniqueCheck.IsSuccessful(name);
        return !isQuoteNameUnique;
    }

    public string Message => "Quote name must be unique";
}
