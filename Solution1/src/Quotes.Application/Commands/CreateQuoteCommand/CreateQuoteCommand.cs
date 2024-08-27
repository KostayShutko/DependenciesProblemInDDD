using MediatR;

namespace Quotes.Application.Commands.CreateQuoteCommand;

public class CreateQuoteCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public Guid CompanyId { get; set; }
    public Guid ConsultantId { get; set; }
    public Guid CustomerId { get; set; }
}
