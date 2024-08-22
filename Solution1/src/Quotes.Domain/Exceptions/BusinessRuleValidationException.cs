using Quotes.Domain.BusinessRules;

namespace Quotes.Domain.Exceptions;

public class BusinessRuleValidationException : Exception
{
    public IBaseBusinessRule BrokenRule { get; }

    public BusinessRuleValidationException(IBusinessRule brokenRule) 
        : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
    }

    public BusinessRuleValidationException(IAsyncBusinessRule brokenRule) 
        : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
    }

    public override string ToString()
    {
        return BrokenRule.Message;
    }
}
