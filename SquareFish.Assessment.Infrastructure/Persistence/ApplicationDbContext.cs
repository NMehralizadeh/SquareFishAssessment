using Microsoft.EntityFrameworkCore;
using SquareFish.Assessment.Domain.Entities;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Infrastructure.Configurations;

namespace SquareFish.Assessment.Infrastructure.Persistence
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookingConfigurations());
            modelBuilder.ApplyConfiguration(new LeaderConfigurations());
            modelBuilder.ApplyConfiguration(new BookingLeaderConfigurations());
            modelBuilder.ApplyConfiguration(new CurrencyConfigurations());
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<BookingLeader> BookingLeaders { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}