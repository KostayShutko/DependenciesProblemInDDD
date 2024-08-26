using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.Users;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.BusinessRules;

public class UserMustExistRule : IAsyncBusinessRule, IHasCheck
{
    private IDoesUserExistCheck check;
    private readonly EntityId id;
    private readonly UserType userType;

    public UserMustExistRule(EntityId id, UserType userType)
    {
        this.id = id;
        this.userType = userType;
    }

    public void UseCheck(ICheck check)
    {
        this.check = (IDoesUserExistCheck)check;
    }

    public Type CheckType => typeof(IDoesUserExistCheck);

    public async Task<bool> IsBroken()
    {
        var result = await check.Execute(id, userType);
        return result.IsFailed;
    }

    public string Message => $"{userType} must exist";
}
