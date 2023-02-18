using AutoMapper;
using Medicine.Application.Folders.Commands.CreateFolder;
using Medicine.Application.Folders.Commands.UpdateFolder;
using Medicine.Application.Folders.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Folders.MappingProfile
{
    internal class FolderMappingProfile : Profile
    {
        public FolderMappingProfile()
        {
            CreateMap<CreateFolderCommand, Folder>();
            CreateMap<UpdateFolderCommand, Folder>();
            CreateMap<Folder, FolderDto>();
        }
    }
}
