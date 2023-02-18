using AutoMapper;
using MediatR;
using Medicine.Application.Attributes.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Attributes.Commands.UpdateDocumentAttribute
{
    public class UpdateDocumentAttributeCommandHandler : IRequestHandler<UpdateDocumentAttributeCommand, DocumentAttributeDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDocumentAttributeCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DocumentAttributeDto> Handle(UpdateDocumentAttributeCommand request, CancellationToken cancellationToken)
        {
            var documentAttribute = await dbContext.FindByIdAsync<DocumentAttribute>(request.Id);
            mapper.Map(request, documentAttribute);
            await dbContext.SaveChangesAsync();
            return mapper.Map<DocumentAttributeDto>(documentAttribute);
        }
    }
}
