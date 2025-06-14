using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Commands.CreateUser;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
 private readonly IMediator _mediator;

 public UsersController(IMediator mediator) {
  _mediator = mediator;
 }

 [HttpPost]
 public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command) {
  var userId = await _mediator.Send(command);
  return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
 }
 
 [HttpGet("{id}")]
 public async Task<IActionResult> GetById(Guid id)
 {
  // Geçici
  return Ok(new { Message = "Not implemented yet", Id = id });
 }
}