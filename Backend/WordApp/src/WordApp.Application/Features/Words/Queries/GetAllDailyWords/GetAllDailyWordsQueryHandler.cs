using MediatR;
using Microsoft.EntityFrameworkCore;
using WordApp.Application.Base;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Queries.GetAllDailyWords;

internal sealed class GetAllDailyWordsQueryHandler : BaseHandler, IRequestHandler<GetAllDailyWordsQueryRequest, IList<GetAllDailyWordsQueryResponse>>
{
    public GetAllDailyWordsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<IList<GetAllDailyWordsQueryResponse>> Handle(GetAllDailyWordsQueryRequest request, CancellationToken cancellationToken)
    {
        IList<Word> wordList = await unitOfWork.GetReadRepository<Word>()
            .GetAllAsync(p => p.KnownType == Domain.Shared.KnownType.UNKNOWN
            && p.LastCheckedTime < DateTime.Now.AddHours(-6),
            include:c=>c.Include(p=>p.Synonms));

        List<GetAllDailyWordsQueryResponse> responses = new();

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