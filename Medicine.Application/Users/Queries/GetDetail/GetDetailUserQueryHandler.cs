using AutoMapper;
using MediatR;
using Medicine.Application.Users.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Users.Queries.GetDetail
{
    public class GetDetailUserQueryHandler : IRequestHandler<GetDetailUserQuery, UserDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailUserQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserDto> Handle(GetDetailUserQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.Id);
            return mapper.Map<UserDto>(user);
        }
    }
}
