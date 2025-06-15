namespace Resume.Application.DTOs;

public record ReferenceDto(Guid ResumeId, string FullName, string Position, string Company, string? Email, string? Phone);