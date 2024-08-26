using Quotes.Domain.BusinessRules.Checks;

namespace Quotes.Infrastructure.Checks;

public class CheckResult : ICheckResult
{
    public CheckResult(bool isSuccessful = true)
    {
        IsSuccessful = isSuccessful;
    }

    public bool IsSuccessful { get; private set; }

    public bool IsFailed => !IsSuccessful;

    public static CheckResult Successful => new CheckResult();

    public static CheckResult Failed => new CheckResult(false);
}
