using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class DocumentCartType : DataBookEntry
    {
        public virtual DocumentCart? DocumentCart { get; set; }
        public int DocumentCartId { get; set; }
        public virtual ICollection<DocumentAttribute>? DocumentAttributes { get; set; }
    }
}
