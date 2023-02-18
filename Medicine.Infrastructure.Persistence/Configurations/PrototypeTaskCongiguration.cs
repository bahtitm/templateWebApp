using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medicine.Infrastructure.Persistence.Configurations
{
    public class PrototypeTaskCongiguration : IEntityTypeConfiguration<Domain.PrototypeTask>
    {
        public void Configure(EntityTypeBuilder<Domain.PrototypeTask> builder)
        {
            builder.HasOne(p => p.Duration)
             .WithMany(p => p.PrototypeTasks)
             .HasForeignKey(p => p.DurationId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
