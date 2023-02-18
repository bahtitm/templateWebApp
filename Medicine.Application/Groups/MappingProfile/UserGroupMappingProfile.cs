using AutoMapper;
using Medicine.Application.Groups.Commands.CreateUserGroup;
using Medicine.Application.Groups.Commands.UpdateUserGroup;
using Medicine.Application.Groups.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Groups.MappingProfile
{
    public class UserGroupMappingProfile : Profile
    {
        public UserGroupMappingProfile()
        {
            CreateMap<CreateUserGroupCommand, UserGroup>();
            CreateMap<UpdateUserGroupCommand, UserGroup>();
            CreateMap<UserGroup, UserGroupDto>();
            CreateMap<UserGroup, UserGroupDetailDto>()
                .ForMember(p => p.UserIds, p => p.MapFrom(p => p.Users.Select(p => p.Id)))
                ;
        }
    }
}
