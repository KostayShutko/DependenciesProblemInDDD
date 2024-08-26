namespace Quotes.Domain.BusinessRules;

public interface IAsyncBusinessRule : IBaseBusinessRule
{
    Task<bool> IsBroken();
}
