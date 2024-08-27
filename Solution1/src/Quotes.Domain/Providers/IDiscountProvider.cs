using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.Providers;

public interface IDiscountProvider
{
    Task<Discount> GetDiscount(EntityId userId);
}
