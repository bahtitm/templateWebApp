using AutoMapper;
using MediatR;
using Medicine.Application.Documents.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Application.Documents.Queries.GetFile
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetFileQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<FileDto> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var documentFile = await dbContext.Set<DocumentFile>().FirstOrDefaultAsync(p => p.Id == request.Id);

            using MemoryStream ms = new MemoryStream();
            var file = File.OpenRead(documentFile.Path);
            file.CopyTo(ms);
            var fileDto = new FileDto
            {
                Name = documentFile.Name,
                File = ms.ToArray(),
            };

            return fileDto;
        }
    }
}
