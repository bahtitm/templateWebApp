using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Permissions.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Permissions.Queries.GetAll
{
    public class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, IQueryable<PermissionDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllPermissionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<PermissionDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Permission>().ProjectTo<PermissionDto>(mapper.ConfigurationProvider));
        }
    }
}
