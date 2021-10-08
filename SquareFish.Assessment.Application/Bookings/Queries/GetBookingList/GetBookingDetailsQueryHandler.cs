using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.Bookings.Queries.GetBookingDetails
{
    public class GetBookingListQueryHandler : IRequestHandler<GetBookingListQuery, List<BookingDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookingListQueryHandler(
            IApplicationDbContext dbContext,
            IMapper mapper
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<BookingDto>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            var startIndex = (request.PageNo - 1) * request.PageCount;
            var entities = _dbContext.Bookings.Skip(startIndex).Take(request.PageCount).ToList<Booking>();

            return _mapper.Map<List<BookingDto>>(entities);
        }
    }
}