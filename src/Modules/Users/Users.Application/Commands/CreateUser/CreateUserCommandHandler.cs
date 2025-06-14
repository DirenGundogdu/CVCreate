using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Exceptions;
using Users.Application.Interfaces;
using Users.Domain.Abstractions;
using Users.Domain.Entities;

namespace Users.Application.Commands.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser is not null)
            throw new AppException("Email is already registered.");

        var hashedPassword = _passwordHasher.Hash(request.PasswordHash);

        var user = new User(
            request.FirstName,
            request.LastName,
            request.Email,
            hashedPassword
        );

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}