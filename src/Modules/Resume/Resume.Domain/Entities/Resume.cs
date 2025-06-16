using Shared.Domain;

namespace Resume.Domain.Entities;

public class Resume : BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    
    public List<Experience> Experiences { get; private set; } = new();
    public List<Education> Educations { get; private set; } = new();
    public List<Skill> Skills { get; private set; } = new();
    public List<Language> Languages { get; private set; } = new();
    public List<Reference> References { get; private set; } = new();
    public List<Link> Links { get; set; } = new();
    
    private Resume() {}
    
    public Resume(Guid userId, string title, string summary)
    {
        UserId = userId;
        Title = title;
        Summary = summary;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddExperiences(List<Experience> experiences)
    {
        if (experiences is not null && experiences.Any())
            Experiences.AddRange(experiences);
    }

    public void AddEducations(List<Education> educations)
    {
        if (educations is not null && educations.Any())
            Educations.AddRange(educations);
    }

    public void AddSkills(List<Skill> skills)
    {
        if (skills is not null && skills.Any())
            Skills.AddRange(skills);
    }

    public void AddLanguages(List<Language> languages)
    {
        if (languages is not null && languages.Any())
            Languages.AddRange(languages);
    }

    public void AddReferences(List<Reference> references)
    {
        if (references is not null && references.Any())
            References.AddRange(references);
    }

    public void AddLinks(List<Link> links)
    {
        if (links is not null && links.Any())
            Links.AddRange(links);
    }

    public void UpdateBasicInfo(string title, string summary)
    {
        Title = title;
        Summary = summary;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ReplaceExperiences(List<Experience> experiences)
    {
        Experiences = experiences;
    }

    public void ReplaceEducations(List<Education> educations)
    {
        Educations = educations;
    }

    public void ReplaceSkills(List<Skill> skills)
    {
        Skills = skills;
    }

    public void ReplaceLanguages(List<Language> languages)
    {
        Languages = languages;
    }

    public void ReplaceReferences(List<Reference> references)
    {
        References = references;
    }

    public void ReplaceLinks(List<Link> links)
    {
        Links = links;
    }
}