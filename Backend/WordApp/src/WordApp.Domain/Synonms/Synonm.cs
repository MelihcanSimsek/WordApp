using WordApp.Domain.Abstractions;
using WordApp.Domain.Words;

namespace WordApp.Domain.Synonms;

public sealed class Synonm : EntityBase
{
    public Guid WordId { get; set; }
    public string ForeignWord { get; set; }
    public string TranslatedWord { get; set; }
    public Word Word { get; set; }

    public Synonm()
    {
        
    }

    public Synonm(Guid id,Guid wordId, string foreignName, string translatedName)
    {
        Id = id;
        WordId = wordId;
        ForeignWord = foreignName;
        TranslatedWord = translatedName;
    }
}
