using MediatR;

namespace Users.Application.Commands.UpdateUser;

public record UpdateUserCommand(Guid Id, string FirstName, string LastName, string Email) : IRequest<bool>;