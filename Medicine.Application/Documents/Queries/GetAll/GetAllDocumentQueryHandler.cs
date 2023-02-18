using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Documents.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Documents.Queries.GetAll
{
    public class GetAllDocumentQueryHandler : IRequestHandler<GetAllDocumentQuery, IQueryable<DocumentDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllDocumentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<DocumentDto>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Document>().ProjectTo<DocumentDto>(mapper.ConfigurationProvider));
        }
    }
}
