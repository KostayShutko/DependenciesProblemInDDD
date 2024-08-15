using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.Entities.Quotes;

public static class QuoteItemExtensions
{
    public static Cost Sum(this IEnumerable<QuoteItem> source, Func<QuoteItem, Cost> selector)
    {
        Cost sum = 0;
        foreach (QuoteItem item in source)
        {
            sum += selector(item);
        }

        return sum;
    }
}