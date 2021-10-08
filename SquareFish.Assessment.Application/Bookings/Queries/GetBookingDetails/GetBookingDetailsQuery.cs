using MediatR;

namespace SquareFish.Assessment.Application.Bookings.Queries.GetBookingDetails
{
    public class GetBookingDetailsQuery : IRequest<BookingDto>
    {
        public int BookingId { get; set; }
    }
}
