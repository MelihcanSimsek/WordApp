using MediatR;
using WordApp.Application.Base;
using WordApp.Application.Features.Words.Rules;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Domain.Synonms;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Commands.AddWord;

internal sealed class AddWordCommandHandler : BaseHandler, IRequestHandler<AddWordCommandRequest, AddWordCommandResponse>
{
    private readonly WordRules wordRules;
    public AddWordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, WordRules wordRules) : base(unitOfWork, mapper)
    {
        this.wordRules = wordRules;
    }

    public async Task<AddWordCommandResponse> Handle(AddWordCommandRequest request, CancellationToken cancellationToken)
    {
        await wordRules
            .IsWordExists(await unitOfWork.GetReadRepository<Word>()
            .GetAsync(p => p.ForeignWord == request.ForeignWord));

        Word newWord = new()
        {
            ForeignWord = request.ForeignWord,
            TranslatedWord = request.TranslatedWord,
            KnownType = Domain.Shared.KnownType.UNKNOWN,
            LastCheckedTime = DateTime.Now.AddDays(-1)
        };

        await unitOfWork.GetWriteRepository<Word>().AddAsync(newWord);
        await AddSynoms(request.Synonms, newWord.Id);
        await unitOfWork.SaveAsync();


        return new();
    }

    private async Task AddSynoms(IList<SynonmDto> synonms,Guid wordId)
    {
        foreach (var synonm in synonms)
        {
            await unitOfWork.GetWriteRepository<Synonm>().AddAsync(new Synonm()
            {
                ForeignWord = synonm.ForeignWord,
                TranslatedWord = synonm.TranslatedWord,
                WordId = wordId
            });
        }
    }
}