using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Documents.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Documents.Queries.GetAllDocumentFile
{
    public class GetAllDocumentFileQueryHandler : IRequestHandler<GetAllDocumentFileQuery, IQueryable<DocumentFileDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllDocumentFileQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<DocumentFileDto>> Handle(GetAllDocumentFileQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<DocumentFile>().Where(p => p.DocumentId == request.DocumentId).ProjectTo<DocumentFileDto>(mapper.ConfigurationProvider));
        }

    }
}
