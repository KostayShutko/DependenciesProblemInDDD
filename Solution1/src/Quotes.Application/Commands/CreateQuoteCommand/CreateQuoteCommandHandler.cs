using MediatR;
using Quotes.Domain.Entities;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands.CreateQuoteCommand;

public class CreateQuoteCommandHandler : BaseCommand<Quote>, IRequestHandler<CreateQuoteCommand, int>
{
    public CreateQuoteCommandHandler(IRepository<Quote> repository)
        : base(repository)
    {
    }

    public async Task<int> Handle(CreateQuoteCommand command, CancellationToken cancellationToken)
    {
        var quote = new Quote();

        var savedQuote = await SaveChangesAsync(quote);

        return savedQuote.Id;
    }
}