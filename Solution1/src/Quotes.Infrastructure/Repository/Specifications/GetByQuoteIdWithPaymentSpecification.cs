using Quotes.Domain.Entities.Quotes;

namespace Quotes.Infrastructure.Repository.Specifications;

public class GetByQuoteIdWithPaymentSpecification : BaseSpecification<Quote>
{
    public GetByQuoteIdWithPaymentSpecification(Guid id)
    {
        SetFilterCondition(quote => quote.Id == id);
        AddInclude(quote => quote.Payment);
    }
}
