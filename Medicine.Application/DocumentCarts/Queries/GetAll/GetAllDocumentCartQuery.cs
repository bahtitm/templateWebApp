using MediatR;
using Medicine.Application.DocumentCarts.Dtos;

namespace Medicine.Application.DocumentCarts.Queries.GetAll
{
    public class GetAllDocumentCartQuery : IRequest<IQueryable<DocumentCartDto>>
    {
    }
}
