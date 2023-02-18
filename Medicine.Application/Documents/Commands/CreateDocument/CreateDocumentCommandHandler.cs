using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommandHandler : AsyncRequestHandler<CreateDocumentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDocumentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = mapper.Map<Document>(request);
            await dbContext.AddAsync(document);
            await dbContext.SaveChangesAsync();
        }
    }

}

