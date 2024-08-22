using Microsoft.Extensions.DependencyInjection;
using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Exceptions;
using static System.Formats.Asn1.AsnWriter;

namespace Quotes.Domain.BusinessRules;

public static class BusinessRulesValidator
{
    private static IServiceProvider serviceProvider;

    public static void Initialize(IServiceProvider provider)
    {
        serviceProvider = provider;
    }

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

        using var serviceScope = serviceProvider.CreateScope();
        var check = serviceScope.ServiceProvider.GetService(type) as ICheck;

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