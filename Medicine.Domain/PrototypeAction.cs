using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class PrototypeAction : DataBookEntry
    {
        public virtual ICollection<Permission>? Permissions { get; set; }
    }
}