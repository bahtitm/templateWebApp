namespace Medicine.Application.Groups.Dtos
{
    public class UserGroupDetailDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<int>? UserIds { get; set; }
        public int? RoleId { get; set; }
    }
}
