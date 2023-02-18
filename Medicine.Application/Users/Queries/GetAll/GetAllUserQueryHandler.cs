using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Users.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Users.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IQueryable<UserDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllUserQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<User>().ProjectTo<UserDto>(mapper.ConfigurationProvider));
        }
    }
}
