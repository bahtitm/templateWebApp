using AutoMapper;
using Medicine.Application.Storages.Commands.CreateStorage;
using Medicine.Application.Storages.Commands.UpdateStorage;
using Medicine.Application.Storages.Commands.UpdateStorageVisibility;
using Medicine.Application.Storages.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Storages.MappingProfile
{
    public class StorageMappingProfile : Profile
    {
        public StorageMappingProfile()
        {
            CreateMap<CreateStorageCommand, Storage>();
            CreateMap<UpdateStorageCommand, Storage>();
            CreateMap<UpdateStorageVisibilityCommand, Storage>();
            CreateMap<Storage, StorageDto>();
        }

    }
}
