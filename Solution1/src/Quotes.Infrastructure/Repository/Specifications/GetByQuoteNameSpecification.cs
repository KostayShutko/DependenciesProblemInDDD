using Quotes.Domain.Entities.Quotes;
using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Infrastructure.Repository.Specifications;

public class GetByQuoteNameSpecification : BaseSpecification<Quote>
{
    public GetByQuoteNameSpecification(Title name)
    {
        SetFilterCondition(quote => quote.Name == name);
    }
}