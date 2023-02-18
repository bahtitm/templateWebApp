using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteRoleCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await dbContext.FindByIdAsync<Role>(request.Id);
            dbContext.Set<Role>().Remove(role);
            await dbContext.SaveChangesAsync();
        }
    }
}
