using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quotes.API.Requests;
using Quotes.Application.Commands.AddQuoteItemCommand;
using Quotes.Application.Commands.ApproveQuoteCommand;
using Quotes.Application.Commands.CompleteQuoteCommand;
using Quotes.Application.Commands.CreateQuoteCommand;
using Quotes.Application.Commands.PayQuoteCommand;
using Quotes.Application.Commands.ReviewQuoteCommand;
using Quotes.Application.Commands.SubmitQuoteCommand;

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

    [HttpPost("{id}/quoteItems")]
    public async Task<IActionResult> AddQuoteItem([FromRoute] Guid id, [FromBody] AddQuoteItemRequest request)
    {
        var command = mapper.Map<AddQuoteItemCommand>(request);
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}/submission")]
    public async Task<IActionResult> SubmitQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new SubmitQuoteCommand { QuoteId = id });
        return Ok(result);
    }

    [HttpPut("{id}/review")]
    public async Task<IActionResult> ReviewQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new ReviewQuoteCommand { QuoteId = id });
        return Ok(result);
    }

    [HttpPut("{id}/approval")]
    public async Task<IActionResult> ApproveQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new ApproveQuoteCommand { QuoteId = id });
        return Ok(result);
    }

    [HttpPut("{id}/payment")]
    public async Task<IActionResult> PayQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new PayQuoteCommand { QuoteId = id });
        return Ok(result);
    }

    [HttpPut("{id}/completion")]
    public async Task<IActionResult> CompleteQuote([FromRoute] Guid id)
    {
        var result = await mediator.Send(new CompleteQuoteCommand { QuoteId = id });
        return Ok(result);
    }
}
