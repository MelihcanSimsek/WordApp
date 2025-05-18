using MediatR;
using WordApp.Application.Base;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Commands.UpdateWordCheckedTime;

internal sealed class UpdateWordCheckedTimeCommandHandler : BaseHandler, IRequestHandler<UpdateWordCheckedTimeCommandRequest, UpdateWordCheckedTimeCommandResponse>
{
    public UpdateWordCheckedTimeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<UpdateWordCheckedTimeCommandResponse> Handle(UpdateWordCheckedTimeCommandRequest request, CancellationToken cancellationToken)
    {
        Word word = await unitOfWork.GetReadRepository<Word>().GetAsync(p => p.Id == request.Id);
        word.LastCheckedTime = DateTime.Now;

        await unitOfWork.GetWriteRepository<Word>().UpdateAsync(word);
        await unitOfWork.SaveAsync();

        return new();
    }
}
