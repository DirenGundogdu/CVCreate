namespace Resume.Application.DTOs;

public record EducationDto(string School, string Degree, string FieldOfStudy, DateTime StartDate, DateTime? EndDate);