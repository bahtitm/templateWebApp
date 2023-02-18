using AutoMapper;
using MediatR;
using Medicine.Application.Folders.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Folders.Queries.GetDetail
{
    public class GetDetailFolderQueryHandler : IRequestHandler<GetDetailFolderQuery, FolderDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailFolderQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<FolderDto> Handle(GetDetailFolderQuery request, CancellationToken cancellationToken)
        {
            var folder = await dbContext.FindByIdAsync<Folder>(request.Id);
            return mapper.Map<FolderDto>(folder);
        }
    }
}
