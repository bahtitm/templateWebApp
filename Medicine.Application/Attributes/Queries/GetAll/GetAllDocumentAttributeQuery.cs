using MediatR;
using Medicine.Application.Attributes.Dtos;

namespace Medicine.Application.Attributes.Queries.GetAll
{
    public class GetAllDocumentAttributeQuery : IRequest<IQueryable<DocumentAttributeDto>>
    {
    }
}
