using MediatR;
using Medicine.Application.Attributes.Dtos;

namespace Medicine.Application.Attributes.Commands.UpdateDocumentAttribute
{
    public class UpdateDocumentAttributeCommand : IRequest<DocumentAttributeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocumentCartTypeId { get; set; }
        public bool IsRequired { get; set; }
    }
}
