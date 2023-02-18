using MediatR;
using Medicine.Application.Folders.Dtos;

namespace Medicine.Application.Folders.Commands.UpdateFolder
{
    public class UpdateFolderCommand : IRequest<FolderDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ParentFolderId { get; set; }
        public int Level { get; set; }
        public int StorageId { get; set; }
    }
}
