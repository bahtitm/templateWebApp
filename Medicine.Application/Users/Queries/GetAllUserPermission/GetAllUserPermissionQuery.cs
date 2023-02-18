using MediatR;
using Medicine.Application.Users.Dtos;

namespace Medicine.Application.Users.Queries.GetAllUserPermission
{
    public class GetAllUserPermissionQuery : IRequest<IQueryable<UserPermissionDto>>
    {
        public GetAllUserPermissionQuery(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public int UserId { get; }
        public string Name { get; }
        public string Password { get; }
    }
}
