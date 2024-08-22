namespace Quotes.Domain.BusinessRules;

public interface IBusinessRule : IBaseBusinessRule
{
    bool IsBroken();
}
