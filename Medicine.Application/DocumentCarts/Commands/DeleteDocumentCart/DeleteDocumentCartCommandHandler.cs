using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.DocumentCarts.Commands.DeleteDocumentCart
{
    public class DeleteDocumentCartCommandHandler : AsyncRequestHandler<DeleteDocumentCartCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteDocumentCartCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteDocumentCartCommand request, CancellationToken cancellationToken)
        {
            var documentCart = await dbContext.FindByIdAsync<DocumentCart>(request.Id);
            dbContext.Set<DocumentCart>().Remove(documentCart);
            await dbContext.SaveChangesAsync();
        }
    }
}
