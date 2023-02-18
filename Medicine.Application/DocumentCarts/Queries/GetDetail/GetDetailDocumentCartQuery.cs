using MediatR;
using Medicine.Application.DocumentCarts.Dtos;

namespace Medicine.Application.DocumentCarts.Queries.GetDetail
{
    public class GetDetailDocumentCartQuery : IRequest<DocumentCartDto>
    {
        public GetDetailDocumentCartQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
