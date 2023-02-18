using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Documents.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Application.Documents.Queries.GetSearchedDocument
{
    public class GetSearchedDocumentQueryHandler : IRequestHandler<GetSearchedDocumentQuery, IQueryable<DocumentDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetSearchedDocumentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<DocumentDto>> Handle(GetSearchedDocumentQuery request, CancellationToken cancellationToken)
        {
            var serchString = $"%{request.Search}%";
            return await Task.FromResult(dbContext.Set<Document>().Where(p => EF.Functions.Like(p.Name.ToLower(), serchString.ToLower()) || EF.Functions.Like(p.Description.ToLower(), serchString.ToLower())).ProjectTo<DocumentDto>(mapper.ConfigurationProvider));
        }
    }
}
