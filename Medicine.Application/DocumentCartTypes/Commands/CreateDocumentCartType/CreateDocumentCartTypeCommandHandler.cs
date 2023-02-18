using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.DocumentCartTypes.Commands.CreateDocumentCartType
{
    public class CreateDocumentCartTypeCommandHandler : AsyncRequestHandler<CreateDocumentCartTypeCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDocumentCartTypeCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateDocumentCartTypeCommand request, CancellationToken cancellationToken)
        {
            var documentCartType = mapper.Map<DocumentCartType>(request);
            await dbContext.AddAsync(documentCartType);
            await dbContext.SaveChangesAsync();
        }
    }
}
