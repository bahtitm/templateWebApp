using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;

namespace Medicine.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : AsyncRequestHandler<CreateCommentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateCommentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = mapper.Map<Comment>(request);
            await dbContext.AddAsync(comment);
            await dbContext.SaveChangesAsync();
        }
    }

}

