using AutoMapper;
using MediatR;
using Resume.Application.DTOs;
using Resume.Domain.Abstractions;

namespace Resume.Application.Queries.GetResumeByUserId;

public class GetResumeByUserIdQueryHandler : IRequestHandler<GetResumeByUserIdQuery, ResumeDto>
{
    private readonly IResumeRepository _repository;
    private readonly IMapper _mapper;
    
    public GetResumeByUserIdQueryHandler(IResumeRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResumeDto> Handle(GetResumeByUserIdQuery request, CancellationToken cancellationToken) {
        var resume = await _repository.GetByUserIdAsync(request.UserId);

        if (resume is null) { return null; }
        
        return _mapper.Map<ResumeDto>(resume);
    }
}