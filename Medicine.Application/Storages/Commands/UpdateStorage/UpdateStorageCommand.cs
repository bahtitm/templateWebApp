using MediatR;
using Medicine.Application.Storages.Dtos;

namespace Medicine.Application.Storages.Commands.UpdateStorage
{
    public class UpdateStorageCommand : IRequest<StorageDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? BuisnessProcessId { get; set; }
    }
}
