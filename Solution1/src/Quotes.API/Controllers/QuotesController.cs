using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quotes.API.Requests;
using Quotes.Application.Commands.AddQuoteItemCommand;
using Quotes.Application.Commands.ApproveQuoteCommand;
using Quotes.Application.Commands.CreateQuoteCommand;
using Quotes.Application.Commands.PayQuoteCommand;

namespace Quotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public QuotesController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteRequest request)
    {
        var command = mapper.Map<CreateQuoteCommand>(request);
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("/Quotes/{id}/quoteItems")]
    public async Task<IActionResult> AddQuoteItem([FromRoute] Guid id, [FromBody] AddQuoteItemRequest request)
    {
        var command = mapper.Map<AddQuoteItemCommand>(request);
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("/Quotes/{id}/approve")]
    public async Task<IActionResult> ApproveQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new ApproveQuoteCommand { QuoteId = id });
        return Ok(result);
    }

    [HttpPut("/Quotes/{id}/pay")]
    public async Task<IActionResult> PayQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new PayQuoteCommand { QuoteId = id });
        return Ok(result);
    }
}
