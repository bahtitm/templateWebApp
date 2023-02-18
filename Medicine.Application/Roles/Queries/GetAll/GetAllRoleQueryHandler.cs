using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Roles.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Roles.Queries.GetAll
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IQueryable<RoleDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllRoleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Role>().ProjectTo<RoleDto>(mapper.ConfigurationProvider));
        }
    }
}
