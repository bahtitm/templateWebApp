using MediatR;
using Medicine.Application.Documents.Dtos;

namespace Medicine.Application.Documents.Queries.GetFile
{
    public class GetFileQuery : IRequest<FileDto>
    {
        public GetFileQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
