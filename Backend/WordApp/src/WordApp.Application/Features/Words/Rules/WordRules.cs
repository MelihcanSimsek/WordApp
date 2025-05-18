using WordApp.Application.Base;
using WordApp.Application.Features.Words.Exceptions;
using WordApp.Domain.Words;

namespace WordApp.Application.Features.Words.Rules;

public class WordRules : BaseRules
{
    public async Task IsWordExists(Word? word)
    {
        if (word is not null) throw new WordAlreadyExistsException();
    }
}
