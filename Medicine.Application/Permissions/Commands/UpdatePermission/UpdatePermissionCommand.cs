using MediatR;
using Medicine.Application.Permissions.Dtos;
using Medicine.Domain.Enums;

namespace Medicine.Application.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest<PermissionDto>
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public ClaimType ClaimType { get; set; }
        public ClaimValue ClaimValue { get; set; }
    }
}
