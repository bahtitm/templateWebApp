using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.DocumentCartTypes.Commands.DeleteDocumentCartType
{
    public class DeleteDocumentCartTypeCommandHandler : AsyncRequestHandler<DeleteDocumentCartTypeCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteDocumentCartTypeCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteDocumentCartTypeCommand request, CancellationToken cancellationToken)
        {
            var documentCartType = await dbContext.FindByIdAsync<DocumentCartType>(request.Id);
            dbContext.Set<DocumentCartType>().Remove(documentCartType);
            await dbContext.SaveChangesAsync();
        }
    }
}
