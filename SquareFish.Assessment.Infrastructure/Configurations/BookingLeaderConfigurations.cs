using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Infrastructure.Configurations
{
    public class BookingLeaderConfigurations : IEntityTypeConfiguration<BookingLeader>
    {
        public void Configure(EntityTypeBuilder<BookingLeader> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.HasKey(bl => new { bl.BookingId, bl.LeaderId });
        }
    }
}