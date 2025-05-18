using MediatR;

namespace WordApp.Application.Features.Words.Commands.AddWord;

public sealed record AddWordCommandRequest(string ForeignWord,string TranslatedWord,IList<SynonmDto> Synonms)
    : IRequest<AddWordCommandResponse>;
