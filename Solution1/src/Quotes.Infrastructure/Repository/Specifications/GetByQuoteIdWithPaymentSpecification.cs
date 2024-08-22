using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Infrastructure.Repository.Specifications;

public class GetByQuoteIdWithPaymentSpecification : BaseSpecification<Quote>
{
    public GetByQuoteIdWithPaymentSpecification(Guid id)
    {
        SetFilterCondition(quote => quote.Id == id);
        AddInclude(quote => quote.Payment);
    }
}
