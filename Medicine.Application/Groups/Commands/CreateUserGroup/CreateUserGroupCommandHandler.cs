using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Groups.Commands.CreateUserGroup
{
    public class CreateUserGroupCommandHandler : AsyncRequestHandler<CreateUserGroupCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateUserGroupCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
        {
            var users = dbContext.Set<User>().Where(p => request.UserIds.Contains(p.Id)).ToList();
            var group = mapper.Map<UserGroup>(request);
            group.Users = users;
            await dbContext.AddAsync(group);
            await dbContext.SaveChangesAsync();
        }

    }
}
