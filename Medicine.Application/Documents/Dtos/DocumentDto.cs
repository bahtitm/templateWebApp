namespace Medicine.Application.Documents.Dtos
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int FolderId { get; set; }
    }
}
