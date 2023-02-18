using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.BuisnessProcessies.Queries.GetAll
{
    public class GetAllBuisnessProcessQueryHandler : IRequestHandler<GetAllBuisnessProcessQuery, IQueryable<BuisnessProcessDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllBuisnessProcessQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<BuisnessProcessDto>> Handle(GetAllBuisnessProcessQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<BuisnessProcess>().ProjectTo<BuisnessProcessDto>(mapper.ConfigurationProvider));
        }
    }
}
