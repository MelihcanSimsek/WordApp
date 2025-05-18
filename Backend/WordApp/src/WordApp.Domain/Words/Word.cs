using WordApp.Domain.Abstractions;
using WordApp.Domain.Shared;
using WordApp.Domain.Synonms;

namespace WordApp.Domain.Words;

public sealed class Word : EntityBase
{
    public string ForeignWord { get; set; }
    public string TranslatedWord { get; set; }
    public DateTime LastCheckedTime { get; set; }
    public KnownType KnownType { get; set; } = KnownType.UNKNOWN;
    public ICollection<Synonm> Synonms { get; set; }

    public Word()
    {
        
    }

    public Word(Guid id,string foreignWord, string translatedWord, DateTime lastCheckedTime, KnownType knownType)
    {
        Id = id;
        ForeignWord = foreignWord;
        TranslatedWord = translatedWord;
        LastCheckedTime = lastCheckedTime;
        KnownType = knownType;
    }
}
