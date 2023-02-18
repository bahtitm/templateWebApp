using Medicine.Domain.Enums;

namespace Medicine.Application.Storages.Dtos
{
    public class StorageDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StorageVisibility StorageVisibility { get; set; }
    }
}
