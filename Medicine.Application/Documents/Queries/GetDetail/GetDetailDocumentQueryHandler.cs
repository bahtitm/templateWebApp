using AutoMapper;
using MediatR;
using Medicine.Application.Documents.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Documents.Queries.GetDetail
{
    public class GetDetailDocumentQueryHandler : IRequestHandler<GetDetailDocumentQuery, DocumentDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailDocumentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DocumentDto> Handle(GetDetailDocumentQuery request, CancellationToken cancellationToken)
        {
            var document = await dbContext.FindByIdAsync<Document>(request.Id);
            return mapper.Map<DocumentDto>(document);
        }
    }
}
