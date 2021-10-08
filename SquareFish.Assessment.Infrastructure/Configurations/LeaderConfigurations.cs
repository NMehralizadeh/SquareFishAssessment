using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Infrastructure.Configurations
{
    public class LeaderConfigurations : BaseEntityConfigurations<Leader>
    {
        public override void Configure(EntityTypeBuilder<Leader> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.FirstName).HasMaxLength(32);
            builder.Property(e => e.LastName).HasMaxLength(32);
            builder.Property(e => e.NationalId).HasMaxLength(10);
            builder.Property(e => e.MobileNumber).HasMaxLength(11);
        }
    }
}