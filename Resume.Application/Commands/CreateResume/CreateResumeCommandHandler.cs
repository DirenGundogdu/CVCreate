using MediatR;
using Resume.Domain.Abstractions;
using Resume.Domain.Entities;

namespace Resume.Application.Commands.CreateResume;

public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, Guid>
{
    private readonly IResumeRepository _resumeRepository;

    public CreateResumeCommandHandler(IResumeRepository resumeRepository) {
        _resumeRepository = resumeRepository;
    }

    public async Task<Guid> Handle(CreateResumeCommand request, CancellationToken cancellationToken) {
        var resume = new Domain.Entities.Resume(request.UserId, request.Title, request.Summary);
        
        resume.AddExperiences(request.Experiences.Select(x => new Experience( 
            resume.Id,
            x.Company,
            x.Position,
            x.Description,
            x.StartDate,
            x.EndDate
        )).ToList());
        
        resume.AddEducations(request.Educations.Select(x => new Education(
            resume.Id,
            x.School,
            x.Degree,
            x.FieldOfStudy,
            x.StartDate,
            x.EndDate
        )).ToList());

        resume.AddSkills(request.Skills.Select(x => new Skill(resume.Id, x.Name, x.Level)).ToList());

        resume.AddLanguages(request.Languages.Select(x => new Language(resume.Id, x.Name, x.Proficiency)).ToList());

        resume.AddReferences(request.References.Select(x => new Reference(
            resume.Id,
            x.FullName,
            x.Position,
            x.Company,
            x.Email,
            x.Phone
        )).ToList());

        resume.AddLinks(request.Links.Select(x => new Link(resume.Id, x.Url, x.Title)).ToList());

        await _resumeRepository.AddAsync(resume);

        return resume.Id;
    }
}