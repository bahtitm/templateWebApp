using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class UserGroup : DataBookEntry
    {
        public virtual Role? Role { get; set; }
        public int? RoleId { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
