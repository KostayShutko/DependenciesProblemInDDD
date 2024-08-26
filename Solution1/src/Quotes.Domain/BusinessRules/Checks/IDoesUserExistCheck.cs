using Quotes.Domain.Entities.Users;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules.Checks;

public interface IDoesUserExistCheck : ICheck
{
    Task<ICheckResult> Execute(EntityId id, UserType userType);
}
