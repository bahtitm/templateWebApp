using AutoMapper;
using MediatR;
using Medicine.Application.Permissions.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Permissions.Queries.GetDetail
{
    public class GetDetailPermissionQueryHandler : IRequestHandler<GetDetailPermissionQuery, PermissionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailPermissionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PermissionDto> Handle(GetDetailPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission = await dbContext.FindByIdAsync<Permission>(request.Id);
            return mapper.Map<PermissionDto>(permission);
        }
    }
}
