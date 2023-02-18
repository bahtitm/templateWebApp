using Medicine.Domain.BaseEntities;
using Medicine.Shared;
using Microsoft.EntityFrameworkCore;

namespace Medicine.DataAccess.Interfaces.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task<T> FindByIdAsync<T>(this IApplicationDbContext dbContext, int id, CancellationToken cancellationToken = default)
            where T : BaseEntity
        {
            var items = dbContext.Set<T>();

            var item = await items.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            return item;
        }
    }
}