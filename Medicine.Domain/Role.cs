using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class Role : DataBookEntry
    {
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Permission>? Permissions { get; set; }

    }
}
