using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.DocumentCartTypes.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.DocumentCartTypes.Queries.GetAll
{
    public class GetAllDocumentCartTypeQueryHandler : IRequestHandler<GetAllDocumentCartTypeQuery, IQueryable<DocumentCartTypeDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllDocumentCartTypeQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<DocumentCartTypeDto>> Handle(GetAllDocumentCartTypeQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<DocumentCartType>().ProjectTo<DocumentCartTypeDto>(mapper.ConfigurationProvider));
        }
    }
}
