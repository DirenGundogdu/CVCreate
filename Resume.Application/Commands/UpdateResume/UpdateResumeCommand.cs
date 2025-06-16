using MediatR;
using Resume.Application.DTOs;

namespace Resume.Application.Commands.UpdateResume;

public record UpdateResumeCommand(Guid ResumeId, Guid UserId, string Title, string Summary, List<ExperienceDto> Experiences, List<EducationDto> Educations,  List<SkillDto> Skills, List<LanguageDto> Languages, List<ReferenceDto> References, List<LinkDto> Links ) : IRequest<Guid>;