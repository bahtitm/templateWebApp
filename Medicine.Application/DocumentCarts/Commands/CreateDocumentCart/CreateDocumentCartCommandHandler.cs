using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.DocumentCarts.Commands.CreateDocumentCart
{
    public class CreateDocumentCartCommandHandler : AsyncRequestHandler<CreateDocumentCartCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDocumentCartCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateDocumentCartCommand request, CancellationToken cancellationToken)
        {
            var documentCart = mapper.Map<DocumentCart>(request);
            await dbContext.AddAsync(documentCart);
            await dbContext.SaveChangesAsync();
        }
    }
}
