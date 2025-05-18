using MediatR;
using Microsoft.EntityFrameworkCore;
using WordApp.Application.Base;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Queries.GetAllKnownWords;

internal sealed class GetAllKnownWordsQueryHandler : BaseHandler, IRequestHandler<GetAllKnownWordsQueryRequest, IList<GetAllKnownWordsQueryResponse>>
{
    public GetAllKnownWordsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<IList<GetAllKnownWordsQueryResponse>> Handle(GetAllKnownWordsQueryRequest request, CancellationToken cancellationToken)
    {
        IList<Word> wordList = await unitOfWork.GetReadRepository<Word>()
           .GetAllAsync(p => p.KnownType == Domain.Shared.KnownType.KNOWN
           && p.LastCheckedTime < DateTime.Now.AddHours(-3),
           include: c => c.Include(p => p.Synonms));

        List<GetAllKnownWordsQueryResponse> responses = new();

        foreach (var word in wordList)
        {
            List<SynonmResponseDto> responseDtos = new();
            foreach (var synonm in word.Synonms)
                responseDtos.Add(new(synonm.Id, synonm.ForeignWord, synonm.TranslatedWord));

            responses.Add(new(word.Id, word.ForeignWord, word.TranslatedWord, responseDtos));
        }

        responses = responses.OrderBy(x => Guid.NewGuid()).ToList();

        return responses;
    }
}