using Microsoft.EntityFrameworkCore;
using SquareFish.Assessment.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SquareFish.Assessment.Application.Interfaces
{
    public partial interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Leader> Leaders { get; set; }
        DbSet<BookingLeader> BookingLeaders { get; set; }
        DbSet<Currency> Currencies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}