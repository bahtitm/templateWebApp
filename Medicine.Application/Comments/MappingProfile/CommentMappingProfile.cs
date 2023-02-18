using AutoMapper;
using Medicine.Application.Comments.Commands.CreateComment;
using Medicine.Application.Comments.Commands.UpdateComment;
using Medicine.Application.Comments.Dtos;
using Medicine.Domain;

namespace Medicine.Application.Comments.MappingProfile
{
    internal class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<UpdateCommentCommand, Comment>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
