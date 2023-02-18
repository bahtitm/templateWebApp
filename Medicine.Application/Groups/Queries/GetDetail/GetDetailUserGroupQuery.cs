using MediatR;
using Medicine.Application.Groups.Dtos;

namespace Medicine.Application.Groups.Queries.GetDetail
{
    public class GetDetailUserGroupQuery : IRequest<UserGroupDetailDto>
    {
        public GetDetailUserGroupQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
