using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteUserCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.Id);
            dbContext.Set<User>().Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
