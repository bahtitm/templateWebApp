using MediatR;
using Medicine.Application.DocumentCartTypes.Dtos;

namespace Medicine.Application.DocumentCartTypes.Queries.GetAll
{
    public class GetAllDocumentCartTypeQuery : IRequest<IQueryable<DocumentCartTypeDto>>
    {
    }
}
