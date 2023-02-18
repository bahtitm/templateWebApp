using AutoMapper;
using Medicine.Application.Permissions.Commands.CreatePermission;
using Medicine.Application.Permissions.Commands.UpdatePermission;
using Medicine.Application.Permissions.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Permissions.MappingProfile
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<CreatePermissionCommand, Permission>();
            CreateMap<UpdatePermissionCommand, Permission>();
            CreateMap<Permission, PermissionDto>();
        }
    }
}
