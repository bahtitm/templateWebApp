using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class PrototypeTask : DataBookEntry
    {
        public string Description { get; set; }
        public virtual Duration? Duration { get; set; }
        public int DurationId { get; set; }
        public virtual ICollection<BuisnessProcessTaskUser>? BuisnessProcessTaskUsers { get; set; }
    }
}
