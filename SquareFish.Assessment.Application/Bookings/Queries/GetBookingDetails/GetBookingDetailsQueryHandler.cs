using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;

namespace SquareFish.Assessment.Application.Bookings.Queries.GetBookingDetails
{
    public class GetBookingDetailsQueryHandler : IRequestHandler<GetBookingDetailsQuery, BookingDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookingDetailsQueryHandler(
            IApplicationDbContext dbContext,
            IMapper mapper
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookingDto> Handle(GetBookingDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Bookings.FirstOrDefault(x => x.Id == request.BookingId);

            if (entity == null)
                throw new NotFoundException($"Booking with Id {request.BookingId} not found");

            return _mapper.Map<BookingDto>(entity);
        }
    }
}