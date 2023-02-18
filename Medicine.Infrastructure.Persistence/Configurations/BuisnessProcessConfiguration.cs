using Medicine.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medicine.Infrastructure.Persistence.Configurations
{
    public class BuisnessProcessConfiguration : IEntityTypeConfiguration<BuisnessProcess>
    {
        public void Configure(EntityTypeBuilder<BuisnessProcess> builder)
        {
            builder.HasOne(p => p.Duration)
              .WithMany(p => p.BuisnessProcesses)
              .HasForeignKey(p => p.DurationId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
