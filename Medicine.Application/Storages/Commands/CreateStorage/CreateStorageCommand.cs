using MediatR;

namespace Medicine.Application.Storages.Commands.CreateStorage
{
    public class CreateStorageCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? BuisnessProcessId { get; set; }
    }
}
