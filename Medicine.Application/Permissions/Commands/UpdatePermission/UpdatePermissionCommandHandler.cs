using AutoMapper;
using MediatR;
using Medicine.Application.Permissions.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, PermissionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdatePermissionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await dbContext.FindByIdAsync<Permission>(request.Id);
            mapper.Map(request, permission);
            await dbContext.SaveChangesAsync();
            return mapper.Map<PermissionDto>(permission);
        }
    }
}
