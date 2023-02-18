using MediatR;

namespace Medicine.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public string? Name { get; set; }
    }
}
