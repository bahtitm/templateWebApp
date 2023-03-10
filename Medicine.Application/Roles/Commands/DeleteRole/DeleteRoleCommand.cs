using MediatR;

namespace Medicine.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public DeleteRoleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
