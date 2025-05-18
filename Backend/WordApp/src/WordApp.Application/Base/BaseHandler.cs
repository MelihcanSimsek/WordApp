using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.UnitOfWorks;

namespace WordApp.Application.Base;

public abstract class BaseHandler
{
    public readonly IUnitOfWork unitOfWork;
    public readonly IMapper mapper;

    protected BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
}
