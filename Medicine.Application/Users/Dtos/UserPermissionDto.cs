using Medicine.Domain.Enums;

namespace Medicine.Application.Users.Dtos
{
    public class UserPermissionDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public ClaimType ClaimType { get; set; }
        public ClaimValue ClaimValue { get; set; }
    }
}
