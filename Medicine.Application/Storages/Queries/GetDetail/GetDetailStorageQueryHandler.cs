using AutoMapper;
using MediatR;
using Medicine.Application.Storages.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Storages.Queries.GetDetail
{
    public class GetDetailStorageQueryHandler : IRequestHandler<GetDetailStorageQuery, StorageDto>
    {

        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailStorageQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<StorageDto> Handle(GetDetailStorageQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<Storage>(request.Id);
            return mapper.Map<StorageDto>(user);
        }
    }
}
