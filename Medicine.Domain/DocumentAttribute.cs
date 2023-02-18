using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class DocumentAttribute : DataBookEntry
    {
        public virtual DocumentCartType? DocumentCartType { get; set; }
        public int DocumentCartTypeId { get; set; }
        public bool IsRequired { get; set; }
    }
}
