using MediatR;

namespace Medicine.Application.DocumentCarts.Commands.CreateDocumentCart
{
    public class CreateDocumentCartCommand : IRequest
    {
        public string? Name { get; set; }
        public int DocumentId { get; set; }
    }
}
