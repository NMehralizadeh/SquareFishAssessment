using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.CQRS.Commands
{
    public class UpdateBookingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public double price { get; set; }
        public int CurrencyId { get; set; }

        public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly ILoggedInUserContext _loggedInUserContext;

            public UpdateBookingCommandHandler(IApplicationDbContext dbContext, ILoggedInUserContext loggedInUserContext)
            {
                _dbContext = dbContext;
                _loggedInUserContext = loggedInUserContext;
            }
            public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
            {
                //Validate
                var booking = _dbContext.Bookings.FirstOrDefault(x => x.Id == request.Id);
                if (booking == null)
                {
                    throw new NotFoundException($"Booking With Id {request.Id} is not available in Database!");
                }

                if (booking.Status == BookingStatus.Accepted && request.Status != BookingStatus.Accepted)
                {
                    throw new BusinessConditionException($"Can not change status of Accepted to other states!");
                }

                booking.Name = request.Name;
                booking.Status = request.Status;
                booking.StartDate = request.StartDate;
                booking.CurrencyId = request.CurrencyId;
                booking.UpdatedAt = DateTime.Now;
                booking.UpdatedBy = _loggedInUserContext.Id;
                await _dbContext.SaveChangesAsync();
                return booking.Id;
            }
        }
    }
}