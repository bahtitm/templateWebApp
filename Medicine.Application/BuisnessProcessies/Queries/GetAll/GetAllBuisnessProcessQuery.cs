using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;

namespace Medicine.Application.BuisnessProcessies.Queries.GetAll
{
    public class GetAllBuisnessProcessQuery : IRequest<IQueryable<BuisnessProcessDto>>
    {
    }
}
