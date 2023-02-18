using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Groups.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Groups.Queries.GetAll
{
    public class GetAllUserGroupQueryHandler : IRequestHandler<GetAllUserGroupQuery, IQueryable<UserGroupDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllUserGroupQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<UserGroupDto>> Handle(GetAllUserGroupQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<UserGroup>().ProjectTo<UserGroupDto>(mapper.ConfigurationProvider));
        }
    }
}
