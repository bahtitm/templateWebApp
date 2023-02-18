using AutoMapper;
using MediatR;
using Medicine.Application.Comments.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.DataAccess.Interfaces.Extensions;
using Medicine.Domain;

namespace Medicine.Application.Comments.Queries.GetDetail
{
    public class GetDetailCommentQueryHandler : IRequestHandler<GetDetailCommentQuery, CommentDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailCommentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetDetailCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await dbContext.FindByIdAsync<Comment>(request.Id);
            return mapper.Map<CommentDto>(comment);
        }
    }
}
