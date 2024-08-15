using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.ApproveQuoteCommand;

public class ApproveQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<ApproveQuoteCommand, Guid>
{
    public ApproveQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(ApproveQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = await FindByIdAsync(command.QuoteId);

        quote.Approve();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}
