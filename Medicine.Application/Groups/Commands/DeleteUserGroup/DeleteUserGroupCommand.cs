using MediatR;

namespace Medicine.Application.Groups.Commands.DeleteUserGroup
{
    public class DeleteUserGroupCommand : IRequest
    {
        public DeleteUserGroupCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
