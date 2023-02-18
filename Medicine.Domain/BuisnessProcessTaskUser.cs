using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class BuisnessProcessTaskUser : BaseEntity
    {
        public virtual User? User { get; set; }
        public int UserId { get; set; }
        public virtual PrototypeTask? PrototypeTask { get; set; }
        public int PrototypeTaskId { get; set; }
        public virtual BuisnessProcess? BuisnessProcess { get; set; }
        public int BuisnessProcessId { get; set; }
        public bool IsManager { get; set; }
    }
}
