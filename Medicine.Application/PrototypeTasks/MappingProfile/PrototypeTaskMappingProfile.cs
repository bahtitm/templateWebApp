using AutoMapper;
using Medicine.Application.PrototypeTasks.Dtos;
using Medicine.Domain;

namespace Medicine.Application.PrototypeTasks.MappingProfile
{
    public class PrototypeTaskMappingProfile : Profile
    {
        public PrototypeTaskMappingProfile()
        {
            CreateMap<PrototypeTask, PrototypeTaskDto>();
        }
    }
}
