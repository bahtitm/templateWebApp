using MediatR;

namespace Medicine.Application.Attributes.Commands.DeleteDocumentAttribute
{
    public class DeleteDocumentAttributeCommand : IRequest
    {
        public DeleteDocumentAttributeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
