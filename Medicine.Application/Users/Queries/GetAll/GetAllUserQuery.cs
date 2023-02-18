using MediatR;
using Medicine.Application.Users.Dtos;

namespace Medicine.Application.Users.Queries.GetAll
{
    public class GetAllUserQuery : IRequest<IQueryable<UserDto>>
    {
    }
}
