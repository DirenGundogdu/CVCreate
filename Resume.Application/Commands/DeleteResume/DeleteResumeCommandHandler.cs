using MediatR;
using Resume.Domain.Abstractions;

namespace Resume.Application.Commands.DeleteResume;

public class DeleteResumeCommandHandler: IRequestHandler<DeleteResumeCommand>
{
    private readonly IResumeRepository _resumeRepository;

    public DeleteResumeCommandHandler(IResumeRepository resumeRepository) {
        _resumeRepository = resumeRepository;
    }

    public async Task<Unit> Handle(DeleteResumeCommand request, CancellationToken cancellationToken) {
        var resume = await _resumeRepository.GetByIdAsync(request.ResumeId);
        
        if(resume is null) {throw new Exception("Resume not found.");}

        await _resumeRepository.DeleteAsync(resume);
        
        return Unit.Value;
    }
}