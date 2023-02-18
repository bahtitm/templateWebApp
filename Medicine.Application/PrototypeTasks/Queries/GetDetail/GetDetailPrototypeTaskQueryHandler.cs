using AutoMapper;
using MediatR;
using Medicine.Application.PrototypeTasks.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.PrototypeTasks.Queries.GetDetail
{
    public class GetDetailPrototypeTaskQueryHandler : IRequestHandler<GetDetailPrototypeTaskQuery, PrototypeTaskDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailPrototypeTaskQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PrototypeTaskDto> Handle(GetDetailPrototypeTaskQuery request, CancellationToken cancellationToken)
        {
            var prototypeTask = await dbContext.FindByIdAsync<PrototypeTask>(request.Id);
            return mapper.Map<PrototypeTaskDto>(prototypeTask);
        }
    }
}
