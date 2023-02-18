using MediatR;

namespace Medicine.Application.Storages.Commands.DeleteStorage
{
    public class DeleteStorageCommand : IRequest
    {
        public DeleteStorageCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
