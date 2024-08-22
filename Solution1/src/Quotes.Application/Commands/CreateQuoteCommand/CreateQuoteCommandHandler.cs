using MediatR;
using Quotes.Domain.Entities.Quotes;
using Quotes.Domain.Entities.ValueObjects;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.CreateQuoteCommand;

public class CreateQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<CreateQuoteCommand, Guid>
{
    public CreateQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<Guid> Handle(CreateQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = Quote.Create();

        await quote.SetName(new Title(command.Name));

        var savedQuote = await SaveChangesAsync(quote, true);

        return savedQuote.Id;
    }
}