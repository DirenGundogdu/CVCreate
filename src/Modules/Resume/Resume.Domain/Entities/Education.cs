using Shared.Domain;

namespace Resume.Domain.Entities;

public class Education : BaseEntity
{
    public Guid ResumeId { get; private set; }
    public string School { get; private set; }
    public string Degree { get; private set; }
    public string FieldOfStudy { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    
    private Education() { } 

    public Education(
        Guid resumeId,
        string school,
        string degree,
        string fieldOfStudy,
        DateTime startDate,
        DateTime? endDate)
    {
        ResumeId = resumeId;
        School = school;
        Degree = degree;
        FieldOfStudy = fieldOfStudy;
        StartDate = startDate;
        EndDate = endDate;
    }
}