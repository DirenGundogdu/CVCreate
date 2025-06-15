using Shared.Domain;

namespace Resume.Domain.Entities;

public class Language : ValueObject
{
    public Guid ResumeId { get; private set; }
    public Resume Resume { get; private set; }
    
    public string Name { get; private set; }
    public string Proficiency { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Proficiency;
    }
    
}