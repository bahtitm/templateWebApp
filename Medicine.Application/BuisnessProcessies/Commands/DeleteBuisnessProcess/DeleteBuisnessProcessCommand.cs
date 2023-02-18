using MediatR;

namespace Medicine.Application.BuisnessProcessies.Commands.DeleteBuisnessProcess
{
    public class DeleteBuisnessProcessCommand : IRequest
    {
        public DeleteBuisnessProcessCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
