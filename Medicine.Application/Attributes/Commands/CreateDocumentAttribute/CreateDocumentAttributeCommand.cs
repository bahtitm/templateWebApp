using MediatR;

namespace Medicine.Application.Attributes.Commands.CreateDocumentAttribute
{
    public class CreateDocumentAttributeCommand : IRequest
    {
        public string? Name { get; set; }
        public int DocumentCartTypeId { get; set; }
        public bool IsRequired { get; set; }
    }
}
