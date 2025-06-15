namespace Resume.Application.DTOs;

public record ResumeDto(
 Guid Id,
 string Title,
 string Summary,
 List<ExperienceDto> Experiences,
 List<EducationDto> Educations,
 List<SkillDto> Skills,
 List<LanguageDto> Languages,  
 List<ReferenceDto> References,  
 List<LinkDto> Links 
 );