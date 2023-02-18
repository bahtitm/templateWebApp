using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandHandler : AsyncRequestHandler<DeletePermissionCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeletePermissionCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await dbContext.FindByIdAsync<Permission>(request.Id);
            dbContext.Set<Permission>().Remove(permission);
            await dbContext.SaveChangesAsync();
        }
    }
}
