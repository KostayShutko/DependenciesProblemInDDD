using MediatR;
using Quotes.Application.Specifications;
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
        var quote = FindBySpecification(new GetByQuoteIdWithPaymentSpecification(command.QuoteId)).First();

        quote.Pay();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}
