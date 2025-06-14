using MediatR;
using Users.Application.DTOs;
using Users.Application.Interfaces;
using Users.Domain.Abstractions;

namespace Users.Application.Commands.LoginUser;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery,LoginResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResponseDto> Handle(LoginUserQuery request, CancellationToken cancellationToken) {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user is null)
        {
            return new LoginResponseDto() {
                Success = false,
                Message = "Invalid email or password"
            };
        }
        var isPasswordValid = _passwordHasher.Verify(user.PasswordHash, request.Password);
        if (!isPasswordValid)
        {
            return new LoginResponseDto() {
                Success = false,
                Message = "Invalid email or password"
            };
        }
        return new LoginResponseDto() {
            Success = true,
            Message = "Login successful"
        };
    }
}