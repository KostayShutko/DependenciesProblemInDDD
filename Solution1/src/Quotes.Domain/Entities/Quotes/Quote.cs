using Quotes.Domain.Entities.ValueObjects;
using Quotes.Domain.BusinessRules;

namespace Quotes.Domain.Entities.Quotes;

public class Quote : Aggregate
{
    public Quote()
    {
        Id = EntityId.New;
        QuoteItems = new List<QuoteItem>();
        CreatedOn = DateTime.UtcNow;
        Status = QuoteStatus.Draft;
        TotalCost = 0;
        TotalCostWithTaxes = 0;
        Discount = Discount.Default;
        CustomerId = new EntityId();
        CompanyId = new EntityId();
        ConsultantId = new EntityId();
    }

    public static Quote Create()
    {
        var quote = new Quote();
        return quote;
    }

    public Title Name { get; private set; }
    public EntityId CustomerId { get; private set; }
    public EntityId CompanyId { get; private set; }
    public EntityId ConsultantId { get; private set; }
    public QuoteStatus Status { get; private set; }
    public Discount Discount { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public virtual Payment Payment { get; private set; }
    public Cost TotalCost { get; private set; }
    public Cost TotalCostWithTaxes { get; private set; }
    public virtual List<QuoteItem> QuoteItems { get; private set; }

    public async Task SetName(Title name)
    {
        await BusinessRulesValidator.CheckRule(new QuoteNameMustBeUniqueRule(name));

        Name = name;
    }

    public void SetCustomer(EntityId customerId)
    {
        CustomerId = customerId;
    }

    public void SetCompanyInfo(EntityId companyId)
    {
        CompanyId = companyId;
    }

    public void SetConsultantId(EntityId consultantId)
    {
        ConsultantId = consultantId;
    }

    public void ApplyDiscount(Discount discount)
    {
        Discount = discount;

        CalculateTotals();
    }

    public void Submit()
    {
        Status = QuoteStatus.Submitted;
    }

    public void Review()
    {
        Status = QuoteStatus.UnderReview;
    }

    public void Approve()
    {
        Payment = new Payment(Id);
        Status = QuoteStatus.Approved;
    }

    public void Amend()
    {
        Status = QuoteStatus.Draft;
    }

    public void Pay()
    {
        Payment.Complete();
        Status = QuoteStatus.Paid;
    }

    public void Complete()
    {
        Status = QuoteStatus.Completed;
    }

    public void Expire()
    {
        Status = QuoteStatus.Expired;
    }

    public void AddQuoteItem(QuoteItem quoteItem)
    {
        QuoteItems.Add(quoteItem);

        CalculateTotals();
    }

    public void RemoveQuoteItem(QuoteItem quoteItem)
    {
        QuoteItems.Remove(quoteItem);

        CalculateTotals();
    }

    private void CalculateTotals()
    {
        Cost itemsCost = QuoteItems.Sum(item => item.TotalCost);
        Cost itemsCostWithDiscount = itemsCost * Discount;
        TotalCost = itemsCostWithDiscount;
        TotalCostWithTaxes = itemsCostWithDiscount * new Tax(0.15M);
    }
}
