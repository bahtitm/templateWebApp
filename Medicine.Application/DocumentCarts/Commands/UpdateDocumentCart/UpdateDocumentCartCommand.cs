using MediatR;
using Medicine.Application.DocumentCarts.Dtos;

namespace Medicine.Application.DocumentCarts.Commands.UpdateDocumentCart
{
    public class UpdateDocumentCartCommand : IRequest<DocumentCartDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DocumentId { get; set; }

    }
}
