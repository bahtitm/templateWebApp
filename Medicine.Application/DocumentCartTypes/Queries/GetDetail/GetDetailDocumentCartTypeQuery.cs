using MediatR;
using Medicine.Application.DocumentCartTypes.Dtos;

namespace Medicine.Application.DocumentCartTypes.Queries.GetDetail
{
    public class GetDetailDocumentCartTypeQuery : IRequest<DocumentCartTypeDto>
    {
        public GetDetailDocumentCartTypeQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
