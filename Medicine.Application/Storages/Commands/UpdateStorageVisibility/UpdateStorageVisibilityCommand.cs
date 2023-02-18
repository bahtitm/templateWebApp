using MediatR;
using Medicine.Application.Storages.Dtos;
using Medicine.Domain.Enums;

namespace Medicine.Application.Storages.Commands.UpdateStorageVisibility
{
    public class UpdateStorageVisibilityCommand : IRequest<StorageDto>
    {
        public int Id { get; set; }
        public StorageVisibility StorageVisibility { get; set; }
    }
}
