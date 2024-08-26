using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules.Checks;

public interface IIsQuoteNameUniqueCheck : ICheck
{
    Task<ICheckResult> Execute(Title name);
}
