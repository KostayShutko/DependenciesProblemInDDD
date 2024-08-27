using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.ReviewQuoteCommand;

public class ReviewQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<ReviewQuoteCommand, Guid>
{
    public ReviewQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(ReviewQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = await FindByIdAsync(command.QuoteId);

        quote.Review();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}