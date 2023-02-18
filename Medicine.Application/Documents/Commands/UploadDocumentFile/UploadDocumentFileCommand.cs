using MediatR;
using Microsoft.AspNetCore.Http;

namespace Medicine.Application.Documents.Commands.UploadDocumentFile
{
    public class UploadDocumentFileCommand : IRequest
    {
        public IFormFile? Files { get; set; }
        public int? DocumentId { get; set; }
    }
}
