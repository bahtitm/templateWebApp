using Medicine.Domain.Enums;

namespace Medicine.Domain.BaseEntities
{
    public abstract class DataBookEntry : BaseEntity
    {
        public string? Name { get; set; }
        public Status Status { get; set; }
    }
}
