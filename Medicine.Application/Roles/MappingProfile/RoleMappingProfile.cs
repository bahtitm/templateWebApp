using AutoMapper;
using Medicine.Application.Roles.Commands.CreateRole;
using Medicine.Application.Roles.Commands.UpdateRole;
using Medicine.Application.Roles.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Roles.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<Role, RoleDto>();
        }
    }
}
