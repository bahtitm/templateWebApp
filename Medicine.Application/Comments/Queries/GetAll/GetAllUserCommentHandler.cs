using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Medicine.Application.Comments.Dtos;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Comments.Queries.GetAll
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, IQueryable<CommentDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllCommentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<CommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Comment>().ProjectTo<CommentDto>(mapper.ConfigurationProvider));
        }
    }
}
