using MediatR;

namespace Medicine.Application.DocumentCartTypes.Commands.CreateDocumentCartType
{
    public class CreateDocumentCartTypeCommand : IRequest
    {
        public string? Name { get; set; }
        public int DocumentCartId { get; set; }
    }
}
