using MediatR;

namespace Medicine.Application.Folders.Commands.CreateFolder
{
    public class CreateFolderCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ParentFolderId { get; set; }
        public int Level { get; set; }
        public int StorageId { get; set; }
    }
}
