using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quotes.Application.Commands.CreateQuoteCommand;

namespace Quotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IMediator mediator;

    public QuotesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuote()
    {
        var result = await mediator.Send(new CreateQuoteCommand());
        return Ok(result);
    }
}
