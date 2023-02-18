using AutoMapper;
using Medicine.Application.DocumentCartTypes.Commands.CreateDocumentCartType;
using Medicine.Application.DocumentCartTypes.Commands.UpdateDocumentCartType;
using Medicine.Application.DocumentCartTypes.Dtos;
using Medicine.Domain;

namespace Medicine.Application.DocumentCartTypes.MappingProfile
{
    public class DocumentCartTypeMappingProfile : Profile
    {
        public DocumentCartTypeMappingProfile()
        {
            CreateMap<CreateDocumentCartTypeCommand, DocumentCartType>();
            CreateMap<UpdateDocumentCartTypeCommand, DocumentCartType>();
            CreateMap<DocumentCartType, DocumentCartTypeDto>();

        }
    }
}
