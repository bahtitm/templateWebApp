using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Folders.Commands.CreateFolder
{
    public class CreateFolderCommandHandler : AsyncRequestHandler<CreateFolderCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateFolderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateFolderCommand request, CancellationToken cancellationToken)
        {
            var folder = mapper.Map<Folder>(request);
            folder.Level = CalculateLevel(folder).Result;
            await dbContext.AddAsync(folder);
            await dbContext.SaveChangesAsync();
        }
        private async Task<int> CalculateLevel(Folder folder)
        {
            int levle = 1;
            if (folder.ParentFolderId == 0)
            {
                return levle;
            }
            else
            {
                var parentfolder = folder;
                do
                {

                    parentfolder = await dbContext.FindByIdAsync<Folder>(parentfolder.ParentFolderId);
                    levle++;
                } while (parentfolder.ParentFolderId > 0);

            }

            return levle;
        }
    }

}

