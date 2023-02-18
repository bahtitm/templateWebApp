using AutoMapper;
using MediatR;
using Medicine.Application.DocumentCarts.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.DocumentCarts.Queries.GetDetail
{
    public class GetDetailDocumentCartQueryHandler : IRequestHandler<GetDetailDocumentCartQuery, DocumentCartDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailDocumentCartQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DocumentCartDto> Handle(GetDetailDocumentCartQuery request, CancellationToken cancellationToken)
        {
            var documentCart = await dbContext.FindByIdAsync<DocumentCart>(request.Id);
            return mapper.Map<DocumentCartDto>(documentCart);
        }
    }
}
