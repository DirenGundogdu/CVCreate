using MediatR;
using Resume.Application.DTOs;

namespace Resume.Application.Commands.CreateResume;

public record CreateResumeCommand(Guid UserId, string Title, string Summary,
    List<ExperienceDto> Experiences,
    List<EducationDto> Educations,
    List<SkillDto> Skills,
    List<LanguageDto> Languages,
    List<ReferenceDto> References,
    List<LinkDto> Links): IRequest<Guid>;