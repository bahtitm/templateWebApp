using MediatR;

namespace Medicine.Application.Folders.Commands.DeleteFolder
{
    public class DeleteFolderCommand : IRequest
    {
        public DeleteFolderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
