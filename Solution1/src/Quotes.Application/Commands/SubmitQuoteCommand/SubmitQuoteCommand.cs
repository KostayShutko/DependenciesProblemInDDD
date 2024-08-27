using MediatR;

namespace Quotes.Application.Commands.SubmitQuoteCommand;

public class SubmitQuoteCommand : IRequest<Guid>
{
    public Guid QuoteId { get; set; }
}