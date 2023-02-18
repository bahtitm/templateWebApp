using MediatR;

namespace Medicine.Application.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommand : IRequest
    {
        public DeleteDocumentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
