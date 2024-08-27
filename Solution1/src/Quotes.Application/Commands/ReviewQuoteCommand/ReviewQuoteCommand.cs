using MediatR;

namespace Quotes.Application.Commands.ReviewQuoteCommand;

public class ReviewQuoteCommand : IRequest<Guid>
{
    public Guid QuoteId { get; set; }
}
