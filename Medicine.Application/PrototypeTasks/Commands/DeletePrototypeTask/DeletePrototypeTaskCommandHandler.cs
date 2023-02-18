using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.PrototypeTasks.Commands.DeletePrototypeTask
{
    public class DeletePrototypeTaskCommandHandler : AsyncRequestHandler<DeletePrototypeTaskCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeletePrototypeTaskCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeletePrototypeTaskCommand request, CancellationToken cancellationToken)
        {
            var prototypeTask = await dbContext.FindByIdAsync<PrototypeTask>(request.Id);
            dbContext.Set<PrototypeTask>().Remove(prototypeTask);
            await dbContext.SaveChangesAsync();
        }
    }
}
