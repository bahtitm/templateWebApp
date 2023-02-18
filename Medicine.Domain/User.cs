using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class User : DataBookEntry
    {
        public string? LastNamre { get; set; }
        public string? MidelName { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public virtual Role? Role { get; set; }
        public int? RoleId { get; set; }
        public virtual ICollection<UserGroup>? UserGroups { get; set; }
        public virtual ICollection<BuisnessProcessTaskUser>? BuisnessProcessTaskUsers { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
