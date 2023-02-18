using MediatR;
using Medicine.Application.DocumentCartTypes.Dtos;

namespace Medicine.Application.DocumentCartTypes.Commands.UpdateDocumentCartType
{
    public class UpdateDocumentCartTypeCommand : IRequest<DocumentCartTypeDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DocumentCartId { get; set; }

    }
}
