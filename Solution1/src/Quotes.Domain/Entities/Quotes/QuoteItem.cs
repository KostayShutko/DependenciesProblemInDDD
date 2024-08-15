using Quotes.Domain.Entities.ValueObjects;

namespace Quotes.Domain.Entities.Quotes;

public class QuoteItem : Entity
{
    public QuoteItem() 
    {
        Id = EntityId.New;
    }

    public static QuoteItem Create(Guid quoteId, string name, string code, string type, int quantity, decimal cost)
    {
        var quoteItem = new QuoteItem();

        quoteItem.QuoteId = new EntityId(quoteId);
        quoteItem.Name = new Title(name);
        quoteItem.Code = new Code(code);
        quoteItem.Type = type;
        quoteItem.Quantity = new Quantity(quantity);
        quoteItem.Cost = new Cost(cost);

        return quoteItem;
    }

    public EntityId QuoteId { get; private set; }
    public Title Name { get; private set; }
    public Code Code { get; private set; }
    public string Type { get; private set; }
    public Quantity Quantity { get; private set; }
    public Cost Cost { get; private set; }
    public Cost TotalCost => Cost * Quantity;
}
