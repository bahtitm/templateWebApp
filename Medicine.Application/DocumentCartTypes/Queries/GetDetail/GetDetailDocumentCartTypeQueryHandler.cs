using AutoMapper;
using MediatR;
using Medicine.Application.DocumentCartTypes.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.DocumentCartTypes.Queries.GetDetail
{
    public class GetDetailDocumentCartTypeQueryHandler : IRequestHandler<GetDetailDocumentCartTypeQuery, DocumentCartTypeDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailDocumentCartTypeQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DocumentCartTypeDto> Handle(GetDetailDocumentCartTypeQuery request, CancellationToken cancellationToken)
        {
            var documentCartType = await dbContext.FindByIdAsync<DocumentCartType>(request.Id);
            return mapper.Map<DocumentCartTypeDto>(documentCartType);
        }
    }
}
