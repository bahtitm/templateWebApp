using MediatR;

namespace Medicine.Application.DocumentCartTypes.Commands.DeleteDocumentCartType
{
    public class DeleteDocumentCartTypeCommand : IRequest
    {
        public DeleteDocumentCartTypeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
