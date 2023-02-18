using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.PrototypeTasks.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.PrototypeTasks.Queries.GetAll
{
    public class GetAllPrototypeTasksQueryHandler : IRequestHandler<GetAllPrototypeTasksQuery, IQueryable<PrototypeTaskDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllPrototypeTasksQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<PrototypeTaskDto>> Handle(GetAllPrototypeTasksQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<PrototypeTask>().ProjectTo<PrototypeTaskDto>(mapper.ConfigurationProvider));
        }
    }
}
