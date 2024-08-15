using Quotes.Domain.Entities;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Database;

namespace Quotes.Infrastructure.Repository;

public class QuotesRepository : Repository<Quote>
{
    public QuotesRepository(QuotesContext context)
        : base(context)
    {
    }
}
