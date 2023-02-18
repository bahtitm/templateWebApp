using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class Comment : DataBookEntry
    {
        public string? Description { get; set; }
        public virtual Document? Document { get; set; }
        public int DocumentId { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
