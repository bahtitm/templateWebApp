using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;

namespace Medicine.Application.BuisnessProcessies.Queries.GetDetail
{
    public class GetDetailBuisnessProcessQuery : IRequest<BuisnessProcessDto>
    {
        public GetDetailBuisnessProcessQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
