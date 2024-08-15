using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.PayQuoteCommand;

public class PayQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<PayQuoteCommand, Guid>
{
    public PayQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(PayQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = await FindByIdAsync(command.QuoteId);

        quote.Pay();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}
