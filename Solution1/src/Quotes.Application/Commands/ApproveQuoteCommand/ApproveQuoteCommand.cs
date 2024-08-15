using MediatR;

namespace Quotes.Application.Commands.ApproveQuoteCommand;

public class ApproveQuoteCommand : IRequest<Guid>
{
    public Guid QuoteId { get; set; }
}
