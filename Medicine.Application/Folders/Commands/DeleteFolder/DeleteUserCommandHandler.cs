using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Application.Folders.Commands.DeleteFolder
{
    public class DeleteFolderCommandHandler : AsyncRequestHandler<DeleteFolderCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteFolderCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteFolderCommand request, CancellationToken cancellationToken)
        {
            var folder = await dbContext.FindByIdAsync<Folder>(request.Id);
            dbContext.Set<Folder>().Remove(folder);
            var chailds = GetFolderChildsAsync(folder).Result;
            dbContext.Set<Folder>().RemoveRange(chailds);
            var folderChailds = await dbContext.Set<Folder>().Where(p => p.ParentFolderId == folder.Id).ToListAsync();
            await dbContext.SaveChangesAsync();
        }

        private async Task<List<Folder>> GetFolderChildsAsync(Folder folder)
        {
            var chailds = new List<Folder>();
            var folderChailds = await dbContext.Set<Folder>().Where(p => p.ParentFolderId == folder.Id).ToListAsync();
            if (folderChailds.Count == 0)
            {
                return chailds;
            }
            chailds.AddRange(folderChailds);
            foreach (var item in folderChailds)
            {
                chailds.AddRange(GetFolderChildsAsync(item).Result);
            }
            return Task.FromResult(chailds).Result;
        }
    }
}
