using MediatR;
using WordApp.Application.Base;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Commands.DeleteWord;

internal sealed class DeleteWordCommandHandler : BaseHandler, IRequestHandler<DeleteWordCommandRequest, DeleteWordCommandResponse>
{
    public DeleteWordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<DeleteWordCommandResponse> Handle(DeleteWordCommandRequest request, CancellationToken cancellationToken)
    {
        Word word = await unitOfWork.GetReadRepository<Word>().GetAsync(p => p.Id == request.Id);
        await unitOfWork.GetWriteRepository<Word>().DeleteAsync(word);
        await unitOfWork.SaveAsync();

        return new();
    }
}
