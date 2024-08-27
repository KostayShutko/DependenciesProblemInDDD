using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.Providers;

public interface ITaxProvider
{
    Task<Tax> GetTax();
}
