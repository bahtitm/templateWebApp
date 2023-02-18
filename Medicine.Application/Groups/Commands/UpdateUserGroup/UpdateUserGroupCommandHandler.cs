using AutoMapper;
using MediatR;
using Medicine.Application.Groups.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Groups.Commands.UpdateUserGroup
{
    public class UpdateUserGroupCommandHandler : IRequestHandler<UpdateUserGroupCommand, UserGroupDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateUserGroupCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserGroupDto> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await dbContext.FindByIdAsync<UserGroup>(request.Id);
            mapper.Map(request, group);
            await dbContext.SaveChangesAsync();
            return mapper.Map<UserGroupDto>(group);
        }
    }
}
