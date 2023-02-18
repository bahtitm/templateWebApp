using AutoMapper;
using MediatR;
using Medicine.Application.DocumentCarts.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.DocumentCarts.Commands.UpdateDocumentCart
{
    public class UpdateDocumentCartCommandHandler : IRequestHandler<UpdateDocumentCartCommand, DocumentCartDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDocumentCartCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DocumentCartDto> Handle(UpdateDocumentCartCommand request, CancellationToken cancellationToken)
        {
            var documentCart = await dbContext.FindByIdAsync<DocumentCart>(request.Id);
            mapper.Map(request, documentCart);
            await dbContext.SaveChangesAsync();
            return mapper.Map<DocumentCartDto>(documentCart);
        }
    }
}
