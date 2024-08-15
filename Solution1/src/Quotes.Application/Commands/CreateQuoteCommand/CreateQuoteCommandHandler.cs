using MediatR;
using Quotes.Domain.Entities.Quotes;
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
        var quote = Quote.Create(
            command.Name
        );

        var savedQuote = await SaveChangesAsync(quote, true);

        return savedQuote.Id;
    }
}