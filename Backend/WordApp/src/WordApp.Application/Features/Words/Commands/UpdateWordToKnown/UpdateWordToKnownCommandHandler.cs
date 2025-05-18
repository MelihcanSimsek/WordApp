using MediatR;
using WordApp.Application.Base;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Commands.UpdateWordToKnown;

internal sealed class UpdateWordToKnownCommandHandler : BaseHandler, IRequestHandler<UpdateWordToKnownCommandRequest, UpdateWordToKnownCommandResponse>
{
    public UpdateWordToKnownCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<UpdateWordToKnownCommandResponse> Handle(UpdateWordToKnownCommandRequest request, CancellationToken cancellationToken)
    {
        Word word = await unitOfWork.GetReadRepository<Word>().GetAsync(p => p.Id == request.Id);
        word.LastCheckedTime = DateTime.Now;
        word.KnownType = Domain.Shared.KnownType.KNOWN;

        await unitOfWork.GetWriteRepository<Word>().UpdateAsync(word);
        await unitOfWork.SaveAsync();

        return new();
    }
}