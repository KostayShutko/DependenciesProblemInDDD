using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.SubmitQuoteCommand;

public class SubmitQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<SubmitQuoteCommand, Guid>
{
    public SubmitQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(SubmitQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = await FindByIdAsync(command.QuoteId);

        quote.Submit();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}