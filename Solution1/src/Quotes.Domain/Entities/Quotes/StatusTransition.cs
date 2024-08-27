namespace Quotes.Domain.Entities.Quotes;

public class StatusTransition
{
    public QuoteStatus From { get; private set; }
    public QuoteStatus To { get; private set; }

    public StatusTransition(QuoteStatus from, QuoteStatus to)
    {
        From = from;
        To = to;
    }

    public bool IsAllowed(QuoteStatus from, QuoteStatus to) => From == from && To == to;
}