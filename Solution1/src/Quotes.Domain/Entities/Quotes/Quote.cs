using Quotes.Domain.Entities.ValueObjects;
using Quotes.Domain.BusinessRules;
using Quotes.Domain.Entities.Users;
using Quotes.Domain.Providers;

namespace Quotes.Domain.Entities.Quotes;

public class Quote : Aggregate
{
    private ITaxProvider taxProvider => ServiceDependencyProvider.GetService<ITaxProvider>();
    private IDiscountProvider discountProvider => ServiceDependencyProvider.GetService<IDiscountProvider>();

    public Quote()
    {
        Id = EntityId.New;
        QuoteItems = new List<QuoteItem>();
        CreatedOn = DateTime.UtcNow;
        Status = QuoteStatus.Draft;
        TotalCost = 0;
        TotalCostWithTaxes = 0;
        Discount = Discount.Default;
        Tax = Tax.Default;
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
    public Tax Tax { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public virtual Payment Payment { get; private set; }
    public Cost TotalCost { get; private set; }
    public Cost TotalCostWithDiscount { get; private set; }
    public Cost TotalCostWithTaxes { get; private set; }
    public virtual List<QuoteItem> QuoteItems { get; private set; }

    public async Task SetName(Title name)
    {
        await BusinessRulesValidator.CheckRule(new QuoteNameMustBeUniqueRule(name));

        Name = name;
    }

    public async Task SetCustomer(EntityId customerId)
    {
        await BusinessRulesValidator.CheckRule(new UserMustExistRule(customerId, UserType.Customer));

        CustomerId = customerId;
    }

    public async Task SetCompany(EntityId companyId)
    {
        await BusinessRulesValidator.CheckRule(new CompanyMustExistRule(companyId));

        CompanyId = companyId;
    }

    public async Task SetConsultant(EntityId consultantId)
    {
        await BusinessRulesValidator.CheckRule(new UserMustExistRule(consultantId, UserType.Consultant));

        ConsultantId = consultantId;
    }

    public async Task ApplyDiscount()
    {
        BusinessRulesValidator.CheckRule(new ValueMustBeNotNullRule(CustomerId));

        Discount = await discountProvider.GetDiscount(CustomerId);

        CalculateTotals();
    }

    public async Task ApplyTax()
    {
        Tax = await taxProvider.GetTax();

        CalculateTotals();
    }

    public void Submit()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.Submitted));

        Status = QuoteStatus.Submitted;
    }

    public void Review()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.UnderReview));

        Status = QuoteStatus.UnderReview;
    }

    public void Approve()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.Approved));

        Payment = new Payment(Id);
        Status = QuoteStatus.Approved;
    }

    public void Amend()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.Draft));

        Status = QuoteStatus.Draft;
    }

    public void Pay()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.Paid));

        Payment.Complete();
        Status = QuoteStatus.Paid;
    }

    public void Complete()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.Completed));

        Status = QuoteStatus.Completed;
    }

    public void Expire()
    {
        BusinessRulesValidator.CheckRule(new StatusTransitionMustBeAllowedRule(Status, QuoteStatus.Expired));

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
        TotalCost = QuoteItems.Sum(item => item.TotalCost);

        Cost discountAmount = TotalCost * Discount;
        TotalCostWithDiscount = TotalCost - discountAmount;

        Cost taxAmount = TotalCostWithDiscount * Tax;
        TotalCostWithTaxes = TotalCostWithDiscount + taxAmount;
    }
}
