using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Exceptions;
using Quotes.Domain.Providers;

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
        if (rule is IHasCheck ruleWithCheck)
        {
            var check = ServiceDependencyProvider.GetService<ICheck>(ruleWithCheck.CheckType);
            ruleWithCheck.UseCheck(check);
        }

        var isBroken = await rule.IsBroken();
        if (isBroken)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}