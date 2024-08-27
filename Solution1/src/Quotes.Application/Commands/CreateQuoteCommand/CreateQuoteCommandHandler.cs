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
        await quote.SetCompany(new EntityId(command.CompanyId));
        await quote.SetConsultant(new EntityId(command.ConsultantId));
        await quote.SetCustomer(new EntityId(command.CustomerId));
        await quote.ApplyDiscount();
        await quote.ApplyTax();

        var savedQuote = await SaveChangesAsync(quote, true);

        return savedQuote.Id;
    }
}