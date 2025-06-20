using Shared.Domain;

namespace Resume.Domain.Entities;

public class Link : ValueObject
{
    public Guid ResumeId { get; private set; }
    public string Url { get; private set; }
    public string Title { get; private set; }
    
    private Link() { }
    public Link(Guid resumeId, string url, string title)
    {
        ResumeId = resumeId;
        Url = url;
        Title = title;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Url;
        yield return Title;
    }
    
}