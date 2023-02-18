namespace Medicine.Application.Documents.Dtos
{
    public class DocumentFileDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public DateTime UploadedDate { get; set; }
        public string? Checksum { get; set; }
        public int? DocumentId { get; set; }
        public int Version { get; set; }
        public string? CheksumFirstPart { get; set; }
        public string? CheksumSecondPart { get; set; }
        public int ParentId { get; set; }
    }
}
