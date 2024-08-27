using Quotes.Domain.BusinessRules.Checks;
using Quotes.Domain.Entities.Quotes;
using Quotes.Domain.Entities.ValueObjects;
using Quotes.Infrastructure.Repository;
using Quotes.Infrastructure.Repository.Specifications;

namespace Quotes.Infrastructure.Checks;

public class IsQuoteNameUniqueCheck : IIsQuoteNameUniqueCheck
{
    private readonly IRepository<Quote> repository;

    public IsQuoteNameUniqueCheck(IRepository<Quote> repository)
    {
        this.repository = repository;
    }

    public async Task<ICheckResult> Execute(Title name)
    {
        var hasAny = await repository.HasAnyAsync(new GetByQuoteNameSpecification(name));
        return hasAny
            ? CheckResult.Failed
            : CheckResult.Successful;
    }
}
