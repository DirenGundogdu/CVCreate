namespace Resume.Application.DTOs;

public record ExperienceDto(string Company, string Position, string Description, DateTime StartDate, DateTime? EndDate);