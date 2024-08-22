using Quotes.Domain.BusinessRules.Checks;

namespace Quotes.Domain.BusinessRules;

public interface IAsyncBusinessRule : IBaseBusinessRule
{
    ICheck Check { get; set; }

    Task<bool> IsBroken();
}
