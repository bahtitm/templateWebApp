using AutoMapper;
using MediatR;
using Medicine.Application.Documents.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Documents.Commands.UpdateDocument
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, DocumentDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDocumentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DocumentDto> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await dbContext.FindByIdAsync<Document>(request.Id);
            mapper.Map(request, document);
            await dbContext.SaveChangesAsync();
            return mapper.Map<DocumentDto>(document);
        }
    }
}
