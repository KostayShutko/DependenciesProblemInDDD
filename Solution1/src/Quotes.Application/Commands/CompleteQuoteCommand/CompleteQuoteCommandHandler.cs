using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.CompleteQuoteCommand;

public class CompleteQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<CompleteQuoteCommand, Guid>
{
    public CompleteQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(CompleteQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = await FindByIdAsync(command.QuoteId);

        quote.Complete();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}