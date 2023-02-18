using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Folders.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Folders.Queries.GetAll
{
    public class GetAllFolderQueryHandler : IRequestHandler<GetAllFolderQuery, IQueryable<FolderDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllFolderQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<FolderDto>> Handle(GetAllFolderQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Folder>().ProjectTo<FolderDto>(mapper.ConfigurationProvider));
        }
    }
}
