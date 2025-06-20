using Shared.Domain;

namespace Resume.Domain.Entities;

public class Experience : BaseEntity
{
    public Guid ResumeId { get; private set; }
    public string Company { get; private set; }
    public string Position { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; } 
    private Experience() { }
    
    public Experience(Guid resumeId, string company, string position, string description, DateTime startDate, DateTime? endDate)
    {
        ResumeId = resumeId;
        Company = company;
        Position = position;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }
}