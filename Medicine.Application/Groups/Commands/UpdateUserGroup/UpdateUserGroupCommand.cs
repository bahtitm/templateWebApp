using MediatR;
using Medicine.Application.Groups.Dtos;

namespace Medicine.Application.Groups.Commands.UpdateUserGroup
{
    public class UpdateUserGroupCommand : IRequest<UserGroupDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
