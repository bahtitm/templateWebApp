using MediatR;
using Medicine.Application.PrototypeTasks.Dtos;

namespace Medicine.Application.PrototypeTasks.Queries.GetDetail
{
    public class GetDetailPrototypeTaskQuery : IRequest<PrototypeTaskDto>
    {
        public GetDetailPrototypeTaskQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
