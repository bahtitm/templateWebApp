using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateRoleCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(request);
            await dbContext.AddAsync(role);
            await dbContext.SaveChangesAsync();
        }
    }
}
