using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.Users;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Infrastructure.Checks;

public class DoesUserExistCheck : IDoesUserExistCheck
{
    public DoesUserExistCheck()
    {
    }

    public async Task<ICheckResult> Execute(EntityId id, UserType userType)
    {
        return await Task.FromResult(CheckResult.Successful);
    }
}
