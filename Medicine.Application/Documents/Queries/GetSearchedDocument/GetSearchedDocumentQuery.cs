using MediatR;
using Medicine.Application.Documents.Dtos;

namespace Medicine.Application.Documents.Queries.GetSearchedDocument
{
    public class GetSearchedDocumentQuery : IRequest<IQueryable<DocumentDto>>
    {
        public GetSearchedDocumentQuery(string search)
        {
            Search = search;
        }

        public string Search { get; }
    }
}
