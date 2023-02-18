using AutoMapper;
using MediatR;
using Medicine.Application.Storages.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Storages.Commands.UpdateStorage
{
    public class UpdateStorageCommandHandler : IRequestHandler<UpdateStorageCommand, StorageDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateStorageCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StorageDto> Handle(UpdateStorageCommand request, CancellationToken cancellationToken)
        {
            var storage = await dbContext.FindByIdAsync<Storage>(request.Id);
            mapper.Map(request, storage);
            await dbContext.SaveChangesAsync();
            return mapper.Map<StorageDto>(storage);
        }
    }
}
