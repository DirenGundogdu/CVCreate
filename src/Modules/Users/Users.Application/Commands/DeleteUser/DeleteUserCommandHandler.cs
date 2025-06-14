using MediatR;
using Users.Domain.Abstractions;

namespace Users.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken) {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null) {return false;}

        await _userRepository.DeleteAsync(user);
        return true;
    }
}