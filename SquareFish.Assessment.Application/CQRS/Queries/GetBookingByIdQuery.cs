using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.CQRS.Queries
{
    public class GetBookingByIdQuery : IRequest<Booking>
    {
        public int Id { get; set; }

        public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
        {
            private IApplicationDbContext _dbContext;
            public GetBookingByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Booking> Handle(GetBookingByIdQuery query, CancellationToken cancellationToken)
            {
                var booking = await _dbContext.Bookings.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return booking;
            }
        }
    }
}