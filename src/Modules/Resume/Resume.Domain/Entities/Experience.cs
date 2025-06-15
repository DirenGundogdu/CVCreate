using Shared.Domain;

namespace Resume.Domain.Entities;

public class Experience : BaseEntity
{
    public Guid ResumeId { get; private set; }
    public Resume Resume { get; private set; }
    
    public string Company { get; private set; }
    public string Position { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; } 
}