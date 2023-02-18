using MediatR;
using Medicine.Application.Comments.Dtos;

namespace Medicine.Application.Comments.Queries.GetAll
{
    public class GetAllCommentQuery : IRequest<IQueryable<CommentDto>>
    {
    }
}
