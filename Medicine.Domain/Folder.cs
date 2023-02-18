using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class Folder : DataBookEntry
    {
        public string? Description { get; set; }
        public int ParentFolderId { get; set; }
        public int Level { get; set; } = 0;
        public virtual Storage? Storage { get; set; }
        public int StorageId { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
