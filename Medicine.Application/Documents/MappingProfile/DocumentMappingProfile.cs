using AutoMapper;
using Medicine.Application.Documents.Commands.CreateDocument;
using Medicine.Application.Documents.Commands.UpdateDocument;
using Medicine.Application.Documents.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Documents.MappingProfile
{
    internal class DocumentMappingProfile : Profile
    {
        public DocumentMappingProfile()
        {
            CreateMap<CreateDocumentCommand, Document>();
            CreateMap<UpdateDocumentCommand, Document>();
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentFile, DocumentFileDto>();
        }
    }
}
