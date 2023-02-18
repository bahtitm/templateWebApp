using AutoMapper;
using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.BuisnessProcessies.Commands.UpdateBuisnessProcess
{
    public class UpdateBuisnessProcessCommanHandler : IRequestHandler<UpdateBuisnessProcessCommand, BuisnessProcessDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateBuisnessProcessCommanHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BuisnessProcessDto> Handle(UpdateBuisnessProcessCommand request, CancellationToken cancellationToken)
        {
            var buisnessProcess = await dbContext.FindByIdAsync<BuisnessProcess>(request.Id);
            mapper.Map(request, buisnessProcess);
            await dbContext.SaveChangesAsync();
            return mapper.Map<BuisnessProcessDto>(buisnessProcess);
        }

    }
}
