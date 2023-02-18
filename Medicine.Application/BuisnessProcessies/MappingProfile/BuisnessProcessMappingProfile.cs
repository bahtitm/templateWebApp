using AutoMapper;
using Medicine.Application.BuisnessProcessies.Commands.CreateBuisnessProcess;
using Medicine.Application.BuisnessProcessies.Commands.UpdateBuisnessProcess;
using Medicine.Application.BuisnessProcessies.Dtos;
using Medicine.Domain;

namespace Medicine.Application.BuisnessProcessies.MappingProfile
{
    public class BuisnessProcessMappingProfile : Profile
    {
        public BuisnessProcessMappingProfile()
        {
            CreateMap<CreateBuisnessProcessCommand, BuisnessProcess>()
                .ForMember(p => p.Duration, p => p.MapFrom(p => new Duration
                { StartDate = p.StartDate.ToUniversalTime(), EndDate = p.EndDate.ToUniversalTime(), SystemStartDate = DateTime.Now.ToUniversalTime() }));

            CreateMap<UpdateBuisnessProcessCommand, BuisnessProcess>();
            CreateMap<BuisnessProcess, BuisnessProcessDto>()
                .ForMember(p => p.StartDate, p => p.MapFrom(p => p.Duration.StartDate))
                .ForMember(p => p.EndDate, p => p.MapFrom(p => p.Duration.EndDate))
                .ForMember(p => p.SystemStartDate, p => p.MapFrom(p => p.Duration.SystemStartDate))
                .ForMember(p => p.SystemEndDate, p => p.MapFrom(p => p.Duration.SystemEndDate));
        }
    }
}
