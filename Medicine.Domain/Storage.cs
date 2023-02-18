using Medicine.Domain.BaseEntities;
using Medicine.Domain.Enums;

namespace Medicine.Domain
{
    public class Storage : DataBookEntry
    {
        public string? Description { get; set; }
        public virtual BuisnessProcess? BuisnessProcess { get; set; }
        public int? BuisnessProcessId { get; set; }
        public virtual ICollection<Folder>? Folders { get; set; }
        public StorageVisibility StorageVisibility { get; set; } = StorageVisibility.Public;
    }
}
