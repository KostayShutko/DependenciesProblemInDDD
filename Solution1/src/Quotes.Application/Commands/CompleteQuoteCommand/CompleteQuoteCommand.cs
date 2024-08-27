using MediatR;

namespace Quotes.Application.Commands.CompleteQuoteCommand;

public class CompleteQuoteCommand : IRequest<Guid>
{
    public Guid QuoteId { get; set; }
}
