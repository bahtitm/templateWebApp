using AutoMapper;
using MediatR;
using Medicine.Application.Attributes.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Attributes.Queries.GetDetail
{
    public class GetDetailDocumentAttributeQueryHandler : IRequestHandler<GetDetailDocumentAttributeQuery, DocumentAttributeDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailDocumentAttributeQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DocumentAttributeDto> Handle(GetDetailDocumentAttributeQuery request, CancellationToken cancellationToken)
        {
            var documentAttribute = await dbContext.FindByIdAsync<DocumentAttribute>(request.Id);
            return mapper.Map<DocumentAttributeDto>(documentAttribute);
        }
    }
}
