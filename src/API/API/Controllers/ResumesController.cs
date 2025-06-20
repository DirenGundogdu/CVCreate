using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Commands.CreateResume;
using Resume.Application.Commands.DeleteResume;
using Resume.Application.Commands.UpdateResume;
using Resume.Application.Queries.GetResumeByUserId;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResumesController(IMediator mediator) {
        _mediator = mediator;
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetResumeByUserId(Guid userId)
    {
        var query = new GetResumeByUserIdQuery(userId);
        var resume = await _mediator.Send(query);

        if (resume is null)
            return NotFound();

        return Ok(resume);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateResume([FromBody] CreateResumeCommand command)
    {
        var resumeId = await _mediator.Send(command);
        return Ok(resumeId);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResume(Guid id, [FromBody] UpdateResumeCommand command)
    {
        if (id != command.ResumeId)
        {
            return BadRequest("Resume ID in route does not match body.");
        }

        var updatedResumeId = await _mediator.Send(command);

        return Ok(updatedResumeId);
    }
    
    [HttpDelete("{resumeId}")]
    public async Task<IActionResult> DeleteResume(Guid resumeId)
    {
        var command = new DeleteResumeCommand(resumeId);
        await _mediator.Send(command);
        return NoContent();
    }

}