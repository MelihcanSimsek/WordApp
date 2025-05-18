namespace WordApp.Application.Features.Words.Queries.GetAllDailyWords;

public sealed record GetAllDailyWordsQueryResponse(Guid Id,string ForeignWord,string TranslatedWord,IList<SynonmResponseDto> Synonms);
