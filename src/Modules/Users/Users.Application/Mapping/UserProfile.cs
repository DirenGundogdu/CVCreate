using AutoMapper;
using Users.Application.Commands.CreateUser;
using Users.Application.DTOs;
using Users.Domain.Entities;

namespace Users.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile() {
        CreateMap<User, UserDto>();

        CreateMap<CreateUserRequestDto, CreateUserCommand>();
    }
}