using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Groups.Commands.DeleteUserGroup
{
    public class DeleteUserGroupCommandHandler : AsyncRequestHandler<DeleteUserGroupCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteUserGroupCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteUserGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await dbContext.FindByIdAsync<UserGroup>(request.Id);
            dbContext.Set<UserGroup>().Remove(group);
            await dbContext.SaveChangesAsync();
        }
    }
}
