namespace Quotes.Domain.BusinessRules.Checks;

public interface IHasCheck
{
    void UseCheck(ICheck check);

    Type CheckType { get; }
}