using AutoMapper;
using Medicine.Application.Attributes.Commands.CreateDocumentAttribute;
using Medicine.Application.Attributes.Commands.UpdateDocumentAttribute;
using Medicine.Application.Attributes.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Attributes.MappingProfile
{
    public class DocumentAttributeMappingProfile : Profile
    {
        public DocumentAttributeMappingProfile()
        {
            CreateMap<CreateDocumentAttributeCommand, DocumentAttribute>();
            CreateMap<UpdateDocumentAttributeCommand, DocumentAttribute>();
            CreateMap<DocumentAttribute, DocumentAttributeDto>();

        }
    }
}
