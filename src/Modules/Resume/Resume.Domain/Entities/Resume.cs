using Shared.Domain;

namespace Resume.Domain.Entities;

public class Resume : BaseEntity
{
    public Guid UserId { get; set; }
    public string JobTitle { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public List<Experience> Experiences { get; private set; } = new();
    public List<Education> Educations { get; private set; } = new();
    public List<Skill> Skills { get; private set; } = new();
    public List<Language> Languages { get; private set; } = new();
    public List<Reference> References { get; private set; } = new();
    public List<Link> Links { get; set; } = new();
    
    private Resume() {}
}