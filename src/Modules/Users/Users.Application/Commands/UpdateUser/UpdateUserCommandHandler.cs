using MediatR;
using Users.Domain.Abstractions;

namespace Users.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user is null) { return false;}

        user.ChangeNameSurname(request.FirstName, request.LastName);

        await _userRepository.UpdateAsync(user);
        return true;
    }
}