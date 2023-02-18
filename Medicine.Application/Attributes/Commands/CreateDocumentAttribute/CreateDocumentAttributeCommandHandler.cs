using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Attributes.Commands.CreateDocumentAttribute
{
    public class CreateDocumentAttributeCommandHandler : AsyncRequestHandler<CreateDocumentAttributeCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDocumentAttributeCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateDocumentAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = mapper.Map<DocumentAttribute>(request);
            await dbContext.AddAsync(attribute);
            await dbContext.SaveChangesAsync();
        }
    }
}
