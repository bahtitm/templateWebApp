using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;

namespace Medicine.Application.BuisnessProcessies.Commands.CreateBuisnessProcess
{
    public class CreateBuisnessProcessCommand : IRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<BPTaskUserDto> BPTaskUsersDto { get; set; } = new List<BPTaskUserDto>();
    }
}
