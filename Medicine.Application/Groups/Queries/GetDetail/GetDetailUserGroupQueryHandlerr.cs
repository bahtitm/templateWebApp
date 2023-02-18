using AutoMapper;
using MediatR;
using Medicine.Application.Groups.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Groups.Queries.GetDetail
{
    public class GetDetailUserGroupQueryHandlerr : IRequestHandler<GetDetailUserGroupQuery, UserGroupDetailDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailUserGroupQueryHandlerr(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserGroupDetailDto> Handle(GetDetailUserGroupQuery request, CancellationToken cancellationToken)
        {
            var group = await dbContext.FindByIdAsync<UserGroup>(request.Id);
            return mapper.Map<UserGroupDetailDto>(group);
        }
    }
}
