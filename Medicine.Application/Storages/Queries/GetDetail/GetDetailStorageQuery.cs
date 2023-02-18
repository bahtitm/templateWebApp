using MediatR;
using Medicine.Application.Storages.Dtos;

namespace Medicine.Application.Storages.Queries.GetDetail
{
    public class GetDetailStorageQuery : IRequest<StorageDto>
    {
        public GetDetailStorageQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
