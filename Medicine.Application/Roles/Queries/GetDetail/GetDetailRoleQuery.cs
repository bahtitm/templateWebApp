using MediatR;
using Medicine.Application.Roles.Dtos;

namespace Medicine.Application.Roles.Queries.GetDetail
{
    public class GetDetailRoleQuery : IRequest<RoleDto>
    {
        public GetDetailRoleQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
