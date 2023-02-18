using MediatR;
using Medicine.Application.Users.Dtos;

namespace Medicine.Application.Users.Queries.GetDetail
{
    public class GetDetailUserQuery : IRequest<UserDto>
    {
        public GetDetailUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
