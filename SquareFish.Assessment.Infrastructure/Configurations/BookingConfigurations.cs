using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Infrastructure.Configurations
{
    public class BookingConfigurations : BaseEntityConfigurations<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).HasMaxLength(64);
            builder.Property(e => e.Slug).HasMaxLength(10);
        }
    }
}