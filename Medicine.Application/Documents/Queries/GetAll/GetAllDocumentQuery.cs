using MediatR;
using Medicine.Application.Documents.Dtos;

namespace Medicine.Application.Documents.Queries.GetAll
{
    public class GetAllDocumentQuery : IRequest<IQueryable<DocumentDto>>
    {
    }
}
