namespace Quotes.API.Requests;

public class CreateQuoteRequest
{
    public string Name { get; set; }
    public Guid CompanyId { get; set; }
    public Guid ConsultantId { get; set; }
    public Guid CustomerId { get; set; }
}
