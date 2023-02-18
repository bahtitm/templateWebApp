using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Storages.Commands.CreateStorage
{
    public class CreateStorageCommandHandler : AsyncRequestHandler<CreateStorageCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateStorageCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateStorageCommand request, CancellationToken cancellationToken)
        {
            var storage = mapper.Map<Storage>(request);
            await dbContext.AddAsync(storage);
            await dbContext.SaveChangesAsync();
        }
    }
}
