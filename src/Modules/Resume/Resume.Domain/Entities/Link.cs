using Shared.Domain;

namespace Resume.Domain.Entities;

public class Link : ValueObject
{
    public Guid ResumeId { get; private set; }
    public Resume Resume { get; private set; }
    
    public string Url { get; private set; }
    public string Title { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Url;
        yield return Title;
    }
    
}