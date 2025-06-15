using MediatR;
using Resume.Application.DTOs;

namespace Resume.Application.Queries.GetResumeByUserId;

public record GetResumeByUserIdQuery(Guid UserId) : IRequest<ResumeDto>;