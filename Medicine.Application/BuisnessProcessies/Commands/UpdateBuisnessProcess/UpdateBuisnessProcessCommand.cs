using MediatR;
using Medicine.Application.BuisnessProcessies.Dtos;

namespace Medicine.Application.BuisnessProcessies.Commands.UpdateBuisnessProcess
{
    public class UpdateBuisnessProcessCommand : IRequest<BuisnessProcessDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
