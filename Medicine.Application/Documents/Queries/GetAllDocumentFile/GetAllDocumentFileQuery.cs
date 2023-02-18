using MediatR;
using Medicine.Application.Documents.Dtos;

namespace Medicine.Application.Documents.Queries.GetAllDocumentFile
{
    public class GetAllDocumentFileQuery : IRequest<IQueryable<DocumentFileDto>>
    {
        public GetAllDocumentFileQuery(int documentId)
        {
            DocumentId = documentId;
        }

        public int DocumentId { get; }
    }
}
