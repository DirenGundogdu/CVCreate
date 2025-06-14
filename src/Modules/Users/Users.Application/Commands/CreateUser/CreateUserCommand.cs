using MediatR;

namespace Users.Application.Commands.CreateUser;

public record CreateUserCommand(string FirstName, string LastName, string Email, string PasswordHash) : IRequest<Guid>;