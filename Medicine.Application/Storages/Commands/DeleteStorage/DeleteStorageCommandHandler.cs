using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Storages.Commands.DeleteStorage
{
    public class DeleteStorageCommandHandler : AsyncRequestHandler<DeleteStorageCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteStorageCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteStorageCommand request, CancellationToken cancellationToken)
        {
            var storage = await dbContext.FindByIdAsync<Storage>(request.Id);
            dbContext.Set<Storage>().Remove(storage);
            await dbContext.SaveChangesAsync();
        }
    }
}
