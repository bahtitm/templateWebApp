using AutoMapper;
using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.BuisnessProcessies.Queries.GetDetail
{
    public class GetDetailBuisnessProcessQueryHandler : IRequestHandler<GetDetailBuisnessProcessQuery, BuisnessProcessDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailBuisnessProcessQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BuisnessProcessDto> Handle(GetDetailBuisnessProcessQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<BuisnessProcess>(request.Id);
            return mapper.Map<BuisnessProcessDto>(user);
        }
    }
}
