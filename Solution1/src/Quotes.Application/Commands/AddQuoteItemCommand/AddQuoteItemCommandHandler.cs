using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.AddQuoteItemCommand;

public class AddQuoteItemCommandHandler : BaseCommand<Quote>, IRequestHandler<AddQuoteItemCommand, Guid>
{
    public AddQuoteItemCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(AddQuoteItemCommand command, CancellationToken cancellationToken)
    {
        var quote = await FindByIdAsync(command.QuoteId);

        var quoteItem = QuoteItem.Create(
            command.QuoteId,
            command.Name,
            command.Code,
            command.Type,
            command.Quantity,
            command.Cost
        );

        quote.AddQuoteItem(quoteItem);

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}
