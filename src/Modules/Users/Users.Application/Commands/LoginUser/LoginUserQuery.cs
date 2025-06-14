using MediatR;
using Users.Application.DTOs;

namespace Users.Application.Commands.LoginUser;

public record LoginUserQuery(string Email, string Password) : IRequest<LoginResponseDto>;