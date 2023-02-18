using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Attributes.Commands.DeleteDocumentAttribute
{
    public class DeleteDocumentAttributeCommandHandler : AsyncRequestHandler<DeleteDocumentAttributeCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteDocumentAttributeCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteDocumentAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await dbContext.FindByIdAsync<DocumentAttribute>(request.Id);
            dbContext.Set<DocumentAttribute>().Remove(attribute);
            await dbContext.SaveChangesAsync();
        }
    }
}
