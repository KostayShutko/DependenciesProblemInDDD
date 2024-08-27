using Quotes.Domain.Entities.ValueObjects;
using Quotes.Domain.Providers;

namespace Quotes.Infrastructure.Providers;

public class TaxProvider : ITaxProvider
{
    public async Task<Tax> GetTax()
    {
        return await Task.FromResult(new Tax(0.1M));
    }
}