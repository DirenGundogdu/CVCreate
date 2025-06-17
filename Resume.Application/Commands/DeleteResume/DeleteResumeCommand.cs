using MediatR;

namespace Resume.Application.Commands.DeleteResume;

public record DeleteResumeCommand(Guid ResumeId): IRequest;