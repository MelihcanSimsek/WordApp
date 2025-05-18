namespace WordApp.Application.Features.Words.Queries.GetAllKnownWords;

public sealed record SynonmResponseDto(Guid Id, string ForeignWord, string TranslatedWord);
