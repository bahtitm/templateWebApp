using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class Document : DataBookEntry
    {
        public string? Description { get; set; }
        public virtual Folder? Folder { get; set; }
        public int FolderId { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<DocumentFile>? DocumentFile { get; set; }
        public virtual ICollection<DocumentCart>? DocumentCarts { get; set; }
    }
}
