using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.BuisnessProcessies.Commands.DeleteBuisnessProcess
{
    public class DeleteBuisnessProcessCommandHandler : AsyncRequestHandler<DeleteBuisnessProcessCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteBuisnessProcessCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteBuisnessProcessCommand request, CancellationToken cancellationToken)
        {
            var buisnessProcess = await dbContext.FindByIdAsync<BuisnessProcess>(request.Id);
            dbContext.Set<BuisnessProcess>().Remove(buisnessProcess);
            await dbContext.SaveChangesAsync();
        }
    }
}
