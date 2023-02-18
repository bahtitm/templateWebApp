using AutoMapper;
using Medicine.Application.DocumentCarts.Commands.CreateDocumentCart;
using Medicine.Application.DocumentCarts.Commands.UpdateDocumentCart;
using Medicine.Application.DocumentCarts.Dtos;
using Medicine.Domain;

namespace Medicine.Application.DocumentCarts.MappingProfile
{
    public class DocumentCartMappingProfile : Profile
    {
        public DocumentCartMappingProfile()
        {
            CreateMap<CreateDocumentCartCommand, DocumentCart>();
            CreateMap<UpdateDocumentCartCommand, DocumentCart>();
            CreateMap<DocumentCart, DocumentCartDto>();

        }
    }
}
