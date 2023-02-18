using MediatR;

namespace Medicine.Application.PrototypeTasks.Commands.ClosePrototypeTask
{
    public class ClosePrototypeTaskCommand : IRequest
    {
        public ClosePrototypeTaskCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
