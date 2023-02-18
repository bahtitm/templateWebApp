using MediatR;
using Medicine.Application.Permissions.Dtos;

namespace Medicine.Application.Permissions.Queries.GetAll
{
    public class GetAllPermissionQuery : IRequest<IQueryable<PermissionDto>>
    {
    }
}
