using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Exceptions;

namespace Quotes.Domain.BusinessRules;

public static class BusinessRulesValidator
{
    public static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    public static async Task CheckRule(IAsyncBusinessRule rule)
    {
        var type = ResolveCheckType(rule);
        var check = ServiceDependencyProvider.GetService<ICheck>(type);

        rule.Check = check;

        var isBroken = await rule.IsBroken();
        if (isBroken)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    private static Type ResolveCheckType(IAsyncBusinessRule rule)
    {
        return rule switch
        {
            QuoteNameMustBeUniqueRule => typeof(IIsQuoteNameUniqueCheck),
            _ => throw new NotImplementedException()
        };
    }
}