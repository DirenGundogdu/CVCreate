using Shared.Domain;

namespace Resume.Domain.Entities;

public class Skill : ValueObject
{
    public Guid ResumeId { get; private set; }
    public string Name { get; private set; }
    public string Level { get; private set; }
    
    
    private Skill() { }
    public Skill(Guid resumeId, string name, string level)
    {
        ResumeId = resumeId;
        Name = name;
        Level = level;
    }
    protected override IEnumerable<object> GetEqualityComponents() {
        yield return Name;
        yield return Level;
    }
}