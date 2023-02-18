using AutoMapper;
using MediatR;
using Medicine.Application.DocumentCartTypes.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.DocumentCartTypes.Commands.UpdateDocumentCartType
{
    public class UpdateDocumentCartTypeCommandHandler : IRequestHandler<UpdateDocumentCartTypeCommand, DocumentCartTypeDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDocumentCartTypeCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DocumentCartTypeDto> Handle(UpdateDocumentCartTypeCommand request, CancellationToken cancellationToken)
        {
            var documentCartType = await dbContext.FindByIdAsync<DocumentCartType>(request.Id);
            mapper.Map(request, documentCartType);
            await dbContext.SaveChangesAsync();
            return mapper.Map<DocumentCartTypeDto>(documentCartType);
        }
    }
}
