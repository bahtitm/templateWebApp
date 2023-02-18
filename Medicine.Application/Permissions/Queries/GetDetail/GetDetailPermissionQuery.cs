using MediatR;
using Medicine.Application.Permissions.Dtos;

namespace Medicine.Application.Permissions.Queries.GetDetail
{
    public class GetDetailPermissionQuery : IRequest<PermissionDto>
    {
        public GetDetailPermissionQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
