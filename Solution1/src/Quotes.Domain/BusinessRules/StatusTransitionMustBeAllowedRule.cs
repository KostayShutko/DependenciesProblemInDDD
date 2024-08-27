using Quotes.Domain.Entities.Quotes;

namespace Quotes.Domain.BusinessRules;

public class StatusTransitionMustBeAllowedRule : IBusinessRule
{
    private readonly QuoteStatus from;
    private readonly QuoteStatus to;

    private static readonly List<StatusTransition> StatusTransitions = new List<StatusTransition>
    {
        new StatusTransition(QuoteStatus.Draft, QuoteStatus.Submitted),
        new StatusTransition(QuoteStatus.Draft, QuoteStatus.Expired),
        new StatusTransition(QuoteStatus.Submitted, QuoteStatus.UnderReview),
        new StatusTransition(QuoteStatus.UnderReview, QuoteStatus.Approved),
        new StatusTransition(QuoteStatus.Approved, QuoteStatus.Draft),
        new StatusTransition(QuoteStatus.Approved, QuoteStatus.Paid),
        new StatusTransition(QuoteStatus.Paid, QuoteStatus.Completed)
    };

    public StatusTransitionMustBeAllowedRule(QuoteStatus from, QuoteStatus to)
    {
        this.from = from;
        this.to = to;
    }

    public bool IsBroken()
    {
        var isAllowed = StatusTransitions.Any(transition => transition.IsAllowed(from, to));

        return !isAllowed;
    }

    public string Message => "Status transition not allowed";
}
