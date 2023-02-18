using MediatR;

namespace Medicine.Application.Groups.Commands.CreateUserGroup
{
    public class CreateUserGroupCommand : IRequest
    {
        public string? Name { get; set; }
        public int? RoleId { get; set; }
        public ICollection<int>? UserIds { get; set; }
    }
}
