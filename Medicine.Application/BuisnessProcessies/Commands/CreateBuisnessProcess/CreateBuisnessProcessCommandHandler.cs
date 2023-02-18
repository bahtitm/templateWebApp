using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.BuisnessProcessies.Commands.CreateBuisnessProcess
{
    public class CreateBuisnessProcessCommandHandler : AsyncRequestHandler<CreateBuisnessProcessCommand>
    {

        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateBuisnessProcessCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        protected override async Task Handle(CreateBuisnessProcessCommand request, CancellationToken cancellationToken)
        {
            var buisnessProcess = mapper.Map<BuisnessProcess>(request);
            foreach (var item in request.BPTaskUsersDto)
            {
                var prototypeTask = new PrototypeTask
                {
                    Duration = new Duration
                    {
                        StartDate = buisnessProcess.Duration.StartDate,
                        SystemStartDate = buisnessProcess.Duration.SystemStartDate,

                    },
                    Name = request.Name,
                    Description = request.Description,
                };
                var buisnessProcessTaskUser = new BuisnessProcessTaskUser
                {
                    PrototypeTask = prototypeTask,
                    BuisnessProcess = buisnessProcess,
                    IsManager = item.IsManager,
                    UserId = item.UserId,
                };
                await dbContext.AddAsync(buisnessProcessTaskUser);
            }
            await dbContext.AddAsync(buisnessProcess);
            await dbContext.SaveChangesAsync();
        }
    }
}
