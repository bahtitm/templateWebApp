using MediatR;

namespace Medicine.Application.DocumentCarts.Commands.DeleteDocumentCart
{
    public class DeleteDocumentCartCommand : IRequest
    {
        public DeleteDocumentCartCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
