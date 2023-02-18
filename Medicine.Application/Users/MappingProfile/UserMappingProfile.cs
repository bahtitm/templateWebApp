using AutoMapper;
using Medicine.Application.Users.Commands.CreateUser;
using Medicine.Application.Users.Commands.UpdateUser;
using Medicine.Application.Users.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Users.MappingProfile
{
    internal class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();
            CreateMap<Permission, UserPermissionDto>();
        }
    }
}
