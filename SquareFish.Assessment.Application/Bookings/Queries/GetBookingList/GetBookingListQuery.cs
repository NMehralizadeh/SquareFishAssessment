using System.Collections.Generic;
using MediatR;

namespace SquareFish.Assessment.Application.Bookings.Queries.GetBookingDetails
{
    public class GetBookingListQuery : IRequest<List<BookingDto>>
    {
        public int PageNo { get; set; }
        public int PageCount { get; set; }
    }
}
