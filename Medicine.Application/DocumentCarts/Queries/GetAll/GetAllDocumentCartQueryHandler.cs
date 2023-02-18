using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.DocumentCarts.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.DocumentCarts.Queries.GetAll
{
    public class GetAllDocumentCartQueryHandler : IRequestHandler<GetAllDocumentCartQuery, IQueryable<DocumentCartDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllDocumentCartQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<DocumentCartDto>> Handle(GetAllDocumentCartQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<DocumentCart>().ProjectTo<DocumentCartDto>(mapper.ConfigurationProvider));
        }
    }
}
