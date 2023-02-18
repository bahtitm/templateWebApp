using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class DocumentCart : DataBookEntry
    {
        public virtual Document? Document { get; set; }
        public int DocumentId { get; set; }
        public virtual ICollection<DocumentCartType>? DocumentCartTypes { get; set; }
    }
}
