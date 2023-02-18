using AutoMapper;
using MediatR;
using Medicine.Application.Folders.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Folders.Commands.UpdateFolder
{
    public class UpdateFolderCommandHandler : IRequestHandler<UpdateFolderCommand, FolderDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateFolderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<FolderDto> Handle(UpdateFolderCommand request, CancellationToken cancellationToken)
        {
            var folder = await dbContext.FindByIdAsync<Folder>(request.Id);
            mapper.Map(request, folder);
            await dbContext.SaveChangesAsync();
            return mapper.Map<FolderDto>(folder);
        }
    }
}
