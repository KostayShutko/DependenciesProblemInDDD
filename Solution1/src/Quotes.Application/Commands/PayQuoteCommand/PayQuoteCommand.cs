using MediatR;

namespace Quotes.Application.Commands.PayQuoteCommand;

public class PayQuoteCommand : IRequest<Guid>
{
    public Guid QuoteId { get; set; }
}
