using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class DocumentFile : DataBookEntry
    {
        public string Path { get; set; }
        public DateTime UploadedDate { get; set; }
        public string? Checksum { get; set; }
        public virtual Document? Document { get; set; }
        public int? DocumentId { get; set; }
        public int Version { get; set; }
        public string? CheksumFirstPart { get; set; }
        public string? CheksumSecondPart { get; set; }
        public int ParentId { get; set; }
    }
}
