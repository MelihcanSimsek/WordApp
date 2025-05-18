using MediatR;

namespace WordApp.Application.Features.Words.Queries.GetAllKnownWords;

public sealed record GetAllKnownWordsQueryRequest() : IRequest<IList<GetAllKnownWordsQueryResponse>>;
