using MediatR;
using Medicine.Application.Comments.Dtos;

namespace Medicine.Application.Comments.Queries.GetDetail
{
    public class GetDetailCommentQuery : IRequest<CommentDto>
    {
        public GetDetailCommentQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
