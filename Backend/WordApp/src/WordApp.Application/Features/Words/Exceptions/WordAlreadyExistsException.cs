using WordApp.Application.Exceptions;
using WordApp.Application.Features.Words.Constants;

namespace WordApp.Application.Features.Words.Exceptions;

public class WordAlreadyExistsException : BusinessException
{
    public WordAlreadyExistsException() : base(Messages.WordAlreadyExists)
    {
        
    }
}
