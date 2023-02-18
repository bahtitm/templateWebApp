using MediatR;
using Medicine.Application.Groups.Dtos;

namespace Medicine.Application.Groups.Queries.GetAll
{
    public class GetAllUserGroupQuery : IRequest<IQueryable<UserGroupDto>>
    {
    }
}
