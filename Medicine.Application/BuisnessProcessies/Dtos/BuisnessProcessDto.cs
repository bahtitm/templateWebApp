using Medicine.Domain.Enums;

namespace Medicine.Application.BuisnessProcessies.Dtos
{
    public class BuisnessProcessDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SystemStartDate { get; set; }
        public DateTime SystemEndDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}
