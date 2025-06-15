using Shared.Domain;

namespace Resume.Domain.Entities;

public class Reference : BaseEntity
{
    public Guid ResumeId { get; private set; }
    public Resume Resume { get; private set; }
    
    public string FullName { get; private set; }
    public string Position { get; private set; }
    public string Company { get; private set; }
    public string? Email { get; private set; }
    public string? Phone { get; private set; }

    
}