namespace Quotes.API.Requests;

public class AddQuoteItemRequest
{
    public Guid QuoteId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
}
