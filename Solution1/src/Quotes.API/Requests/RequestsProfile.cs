using AutoMapper;
using Quotes.Application.Commands.AddQuoteItemCommand;
using Quotes.Application.Commands.CreateQuoteCommand;

namespace Quotes.API.Requests;

public class RequestsProfile : Profile
{
    public RequestsProfile()
    {
        CreateMap<AddQuoteItemRequest, AddQuoteItemCommand>();
        CreateMap<CreateQuoteRequest, CreateQuoteCommand>();
    }
}
