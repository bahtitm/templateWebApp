using MediatR;
using Medicine.Application.Storages.Dtos;

namespace Medicine.Application.Storages.Queries.GetAll
{
    public class GetAllStorageQuery : IRequest<IQueryable<StorageDto>>
    {

    }
}
