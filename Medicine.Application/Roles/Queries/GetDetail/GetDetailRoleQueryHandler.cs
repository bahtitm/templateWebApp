using AutoMapper;
using MediatR;
using Medicine.Application.Roles.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Roles.Queries.GetDetail
{
    public class GetDetailRoleQueryHandler : IRequestHandler<GetDetailRoleQuery, RoleDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailRoleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetDetailRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await dbContext.FindByIdAsync<Role>(request.Id);
            return mapper.Map<RoleDto>(role);
        }
    }
}
