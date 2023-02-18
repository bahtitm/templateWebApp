using MediatR;
using Medicine.Application.Documents.Dtos;

namespace Medicine.Application.Documents.Queries.GetDetail
{
    public class GetDetailDocumentQuery : IRequest<DocumentDto>
    {
        public GetDetailDocumentQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
