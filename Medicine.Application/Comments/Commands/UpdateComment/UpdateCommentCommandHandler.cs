using AutoMapper;
using MediatR;
using Medicine.Application.Comments.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateCommentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await dbContext.FindByIdAsync<Comment>(request.Id);
            mapper.Map(request, comment);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CommentDto>(comment);
        }
    }
}
