using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Infrastructure.Checks;

public class DoesCompanyExistCheck : IDoesCompanyExistCheck
{
    public DoesCompanyExistCheck()
    {
    }

    public async Task<ICheckResult> Execute(EntityId id)
    {
        return await Task.FromResult(CheckResult.Successful);
    }
}