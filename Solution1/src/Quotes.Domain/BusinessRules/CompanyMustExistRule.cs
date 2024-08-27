using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules;

public class CompanyMustExistRule : IAsyncBusinessRule, IHasCheck
{
    private IDoesCompanyExistCheck check;
    private readonly EntityId id;

    public CompanyMustExistRule(EntityId id)
    {
        this.id = id;
    }

    public void UseCheck(ICheck check)
    {
        this.check = (IDoesCompanyExistCheck)check;
    }

    public Type CheckType => typeof(IDoesCompanyExistCheck);

    public async Task<bool> IsBroken()
    {
        var result = await check.Execute(id);
        return result.IsFailed;
    }

    public string Message => $"Company must exist";
}