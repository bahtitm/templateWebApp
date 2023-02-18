using Medicine.Domain.Enums;

namespace Medicine.Application.PrototypeTasks.Dtos
{
    public class PrototypeTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
    }
}
