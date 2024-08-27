using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules.Checks;

public interface IDoesCompanyExistCheck : ICheck
{
    Task<ICheckResult> Execute(EntityId id);
}
