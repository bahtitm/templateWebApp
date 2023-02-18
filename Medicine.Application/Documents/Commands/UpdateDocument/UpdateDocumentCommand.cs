using MediatR;
using Medicine.Application.Documents.Dtos;

namespace Medicine.Application.Documents.Commands.UpdateDocument
{
    public class UpdateDocumentCommand : IRequest<DocumentDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int FolderId { get; set; }
    }
}
