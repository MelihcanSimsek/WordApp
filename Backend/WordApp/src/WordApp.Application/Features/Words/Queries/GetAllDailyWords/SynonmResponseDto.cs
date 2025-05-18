namespace WordApp.Application.Features.Words.Queries.GetAllDailyWords;

public sealed record SynonmResponseDto(Guid Id, string ForeignWord, string TranslatedWord);
