using MediatR;

namespace Medicine.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int FolderId { get; set; }
    }
}
