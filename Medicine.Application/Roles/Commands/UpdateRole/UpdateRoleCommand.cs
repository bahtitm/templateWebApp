using MediatR;
using Medicine.Application.Roles.Dtos;

namespace Medicine.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<RoleDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
