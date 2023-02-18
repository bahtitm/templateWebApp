using MediatR;

namespace Medicine.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
