using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Storages.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Storages.Queries.GetAll
{
    public class GetAllStorageQueryHandler : IRequestHandler<GetAllStorageQuery, IQueryable<StorageDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllStorageQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<StorageDto>> Handle(GetAllStorageQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Storage>().ProjectTo<StorageDto>(mapper.ConfigurationProvider));
        }
    }
}
