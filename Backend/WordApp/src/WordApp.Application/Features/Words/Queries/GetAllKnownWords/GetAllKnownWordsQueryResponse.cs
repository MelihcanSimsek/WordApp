namespace WordApp.Application.Features.Words.Queries.GetAllKnownWords;

public sealed record GetAllKnownWordsQueryResponse(Guid Id, string ForeignWord, string TranslatedWord, IList<SynonmResponseDto> Synonms);
