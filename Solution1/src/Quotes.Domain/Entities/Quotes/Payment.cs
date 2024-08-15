using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.Entities.Quotes;

public class Payment : Entity
{
    public Payment(EntityId quoteId)
    {
        Id = EntityId.New;
        QuoteId = quoteId;
        CreatedOn = DateTime.UtcNow;
        Status = PaymentStatus.Pending;
    }

    public EntityId QuoteId { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public PaymentStatus Status { get; private set; }

    public void Complete()
    {
        Status = PaymentStatus.Paid;
    }
}
