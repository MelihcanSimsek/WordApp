using MediatR;

namespace WordApp.Application.Features.Words.Queries.GetAllDailyWords;

public sealed record GetAllDailyWordsQueryRequest() : IRequest<IList<GetAllDailyWordsQueryResponse>>;
