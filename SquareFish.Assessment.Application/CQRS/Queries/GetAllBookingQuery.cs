using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.CQRS.Queries
{
    public class GetAllBookingQuery : IRequest<IEnumerable<Booking>>
    {
        public GetAllBookingQuery()
        {
            PageCount = 10;
        }
        public int PageNo { get; set; }
        public int PageCount { get; set; }
        public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, IEnumerable<Booking>>
        {
            private IApplicationDbContext _dbContext;
            public GetAllBookingQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<IEnumerable<Booking>> Handle(GetAllBookingQuery query, CancellationToken cancellationToken)
            {
                var startIndex = (query.PageNo - 1) * query.PageCount;
                var bookingList = await _dbContext.Bookings.Skip(startIndex).Take(query.PageCount).ToListAsync<Booking>();
                return bookingList;
            }
        }
    }
}