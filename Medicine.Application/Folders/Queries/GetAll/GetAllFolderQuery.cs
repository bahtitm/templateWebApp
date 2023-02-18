using MediatR;
using Medicine.Application.Folders.Dtos;

namespace Medicine.Application.Folders.Queries.GetAll
{
    public class GetAllFolderQuery : IRequest<IQueryable<FolderDto>>
    {
    }
}
