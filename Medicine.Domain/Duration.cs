using Medicine.Domain.BaseEntities;

namespace Medicine.Domain
{
    public class Duration : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SystemStartDate { get; set; }
        public DateTime SystemEndDate { get; set; }
        public virtual ICollection<BuisnessProcess>? BuisnessProcesses { get; set; }
        public virtual ICollection<PrototypeTask>? PrototypeTasks { get; set; }
    }
}
