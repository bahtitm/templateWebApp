using MediatR;
using Medicine.Application.Comments.Dtos;

namespace Medicine.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<CommentDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DocumentId { get; set; }
    }
}
