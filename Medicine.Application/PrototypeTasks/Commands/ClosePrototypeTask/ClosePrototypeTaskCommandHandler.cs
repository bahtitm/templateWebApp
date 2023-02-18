using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;
using Medicine.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Application.PrototypeTasks.Commands.ClosePrototypeTask
{
    public class ClosePrototypeTaskCommandHandler : AsyncRequestHandler<ClosePrototypeTaskCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public ClosePrototypeTaskCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(ClosePrototypeTaskCommand request, CancellationToken cancellationToken)
        {
            var prototypeTask = await dbContext.FindByIdAsync<PrototypeTask>(request.Id);
            prototypeTask.Status = Status.Closed;

            var buisnessProcessTaskUser = await dbContext.Set<BuisnessProcessTaskUser>()
                                                        .Where(p => p.PrototypeTaskId == prototypeTask.Id).FirstOrDefaultAsync();
            var buisnessProcess = await dbContext.FindByIdAsync<BuisnessProcess>(buisnessProcessTaskUser.BuisnessProcessId);
            var prototypeTasks = await dbContext.Set<BuisnessProcessTaskUser>()
                .Where(p => p.BuisnessProcessId == buisnessProcessTaskUser.BuisnessProcessId && p.PrototypeTaskId != request.Id).Select(p => p.PrototypeTask).ToListAsync();

            if (prototypeTasks.All(p => p.Status == Status.Closed))
            {
                buisnessProcess.Status = Status.Closed;
                buisnessProcess.Duration.EndDate = DateTime.Now;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
