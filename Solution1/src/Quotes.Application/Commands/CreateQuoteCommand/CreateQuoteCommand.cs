using MediatR;

namespace Quotes.Application.Commands.CreateQuoteCommand;

public class CreateQuoteCommand : IRequest<Guid>
{
    public string Name { get; set; }
}
