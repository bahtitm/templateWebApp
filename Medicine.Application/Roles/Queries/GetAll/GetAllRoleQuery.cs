using MediatR;
using Medicine.Application.Roles.Dtos;

namespace Medicine.Application.Roles.Queries.GetAll
{
    public class GetAllRoleQuery : IRequest<IQueryable<RoleDto>>
    {

    }
}
