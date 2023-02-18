using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class BuisnessProcess : DataBookEntry
    {
        public string Description { get; set; } = string.Empty;
        public virtual Duration? Duration { get; set; }
        public int DurationId { get; set; }
        public virtual ICollection<BuisnessProcessTaskUser>? BuisnessProcessTaskUsers { get; set; }
        public virtual ICollection<Storage>? Storages { get; set; }
    }
}
