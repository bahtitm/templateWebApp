using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Attributes.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Attributes.Queries.GetAll
{
    public class GetAllDocumentAttributeQueryHandler : IRequestHandler<GetAllDocumentAttributeQuery, IQueryable<DocumentAttributeDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllDocumentAttributeQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<DocumentAttributeDto>> Handle(GetAllDocumentAttributeQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<DocumentAttribute>().ProjectTo<DocumentAttributeDto>(mapper.ConfigurationProvider));
        }
    }
}
