using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommandHandler : AsyncRequestHandler<DeleteDocumentCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteDocumentCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await dbContext.FindByIdAsync<Document>(request.Id);
            dbContext.Set<Document>().Remove(document);
            await dbContext.SaveChangesAsync();
        }
    }
}
