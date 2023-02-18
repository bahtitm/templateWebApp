using MediatR;
using Medicine.Application.Folders.Dtos;

namespace Medicine.Application.Folders.Queries.GetDetail
{
    public class GetDetailFolderQuery : IRequest<FolderDto>
    {
        public GetDetailFolderQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
