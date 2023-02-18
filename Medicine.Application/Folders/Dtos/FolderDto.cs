namespace Medicine.Application.Folders.Dtos
{
    public class FolderDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ParentFolderId { get; set; }
        public int Level { get; set; }
        public int StorageId { get; set; }
    }
}
