using MediatR;
using Medicine.Application.PrototypeTasks.Dtos;

namespace Medicine.Application.PrototypeTasks.Queries.GetAll
{
    public class GetAllPrototypeTasksQuery : IRequest<IQueryable<PrototypeTaskDto>>
    {

    }
}
