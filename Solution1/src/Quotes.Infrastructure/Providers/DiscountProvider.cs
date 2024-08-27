using Quotes.Domain.Entities.ValueObjects;
using Quotes.Domain.Providers;

namespace Quotes.Infrastructure.Providers;

public class DiscountProvider : IDiscountProvider
{
    public async Task<Discount> GetDiscount(EntityId userId)
    {
        return await Task.FromResult(new Discount(0.1M));
    }
}
