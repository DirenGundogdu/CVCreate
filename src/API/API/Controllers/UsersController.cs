using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Commands.CreateUser;
using Users.Application.Commands.LoginUser;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
 private readonly IMediator _mediator;

 public UsersController(IMediator mediator) {
  _mediator = mediator;
 }

 [HttpPost("create")]
 public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command) {
  var userId = await _mediator.Send(command);
  if (userId != Guid.Empty) 
  {
   return Ok(new { Success = true, UserId = userId });
  }
  return BadRequest(new { Success = false, Message = "User creation failed." });
 }
 
 [HttpPost("login")]
 public async Task<IActionResult> LoginUser([FromBody] LoginUserQuery query) {
  var response = await _mediator.Send(query);
  if (response.Success)
  {
   return Ok(response);
  }
  return Unauthorized(response);
 }
 
}