using MediatR;
using Resume.Domain.Abstractions;
using Resume.Domain.Entities;

namespace Resume.Application.Commands.UpdateResume;

public class UpdateResumeCommandHandler : IRequestHandler<UpdateResumeCommand, Guid>
{
    private readonly IResumeRepository _resumeRepository;

    public UpdateResumeCommandHandler(IResumeRepository resumeRepository) {
        _resumeRepository = resumeRepository;
    }

    public async Task<Guid> Handle(UpdateResumeCommand request, CancellationToken cancellationToken) {
        var resume = await _resumeRepository.GetByIdAsync(request.ResumeId);
        if (resume is null) { throw new Exception("Resume not found."); }
        
        resume.UpdateBasicInfo(request.Title, request.Summary);
        resume.ReplaceExperiences(request.Experiences.Select(x => new Experience(
            resume.Id, x.Company, x.Position, x.Description, x.StartDate, x.EndDate
        )).ToList());
        
        resume.ReplaceEducations(request.Educations.Select(x => new Education(
            resume.Id, x.School, x.Degree, x.FieldOfStudy, x.StartDate, x.EndDate
        )).ToList());

        resume.ReplaceSkills(request.Skills.Select(x => new Skill(resume.Id, x.Name, x.Level)).ToList());

        resume.ReplaceLanguages(request.Languages.Select(x => new Language(resume.Id, x.Name, x.Proficiency)).ToList());

        resume.ReplaceReferences(request.References.Select(x => new Reference(
            resume.Id, x.FullName, x.Position, x.Company, x.Email, x.Phone
        )).ToList());

        resume.ReplaceLinks(request.Links.Select(x => new Link(resume.Id, x.Url, x.Title)).ToList());

        await _resumeRepository.UpdateAsync(resume);

        return resume.Id;

    }
}