namespace Quotes.Domain.BusinessRules.Checks;

public interface ICheckResult
{
    bool IsSuccessful { get; }

    bool IsFailed { get; }
}
