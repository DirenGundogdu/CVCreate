using MediatR;

namespace Users.Application.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest<bool>;