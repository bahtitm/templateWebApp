using MediatR;

namespace Medicine.Application.PrototypeTasks.Commands.DeletePrototypeTask
{
    public class DeletePrototypeTaskCommand : IRequest
    {
        public DeletePrototypeTaskCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
