using Medicine.DataAccess.Interfaces;
using Medicine.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Authorization.StorageHandlers
{
    public class IsManagerHandler : AuthorizationHandler<IsManagerRequirement, int>
    {
        private readonly IApplicationDbContext dbContext;

        public IsManagerHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsManagerRequirement requirement, int resurse)
        {
            var userName = context.User.Claims.Where(p => p.Type.Equals("UserName")).Select(p => p.Value).FirstOrDefault();
            var user = dbContext.Set<User>().Where(p => p.Name.Equals(userName)).FirstOrDefaultAsync().Result;
            var buisnessProcess = dbContext.Set<Storage>().Where(p => p.Id == resurse).Select(p => p.BuisnessProcess).FirstOrDefaultAsync().Result;

            if (buisnessProcess.BuisnessProcessTaskUsers.Where(p => p.UserId == user.Id).FirstOrDefault().IsManager)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
