using MediatR;
using Medicine.Application.Attributes.Dtos;

namespace Medicine.Application.Attributes.Queries.GetDetail
{
    public class GetDetailDocumentAttributeQuery : IRequest<DocumentAttributeDto>
    {
        public GetDetailDocumentAttributeQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
