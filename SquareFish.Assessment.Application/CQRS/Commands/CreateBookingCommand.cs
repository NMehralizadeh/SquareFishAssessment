using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.CQRS.Commands
{
    public class CreateBookingCommand : IRequest<int>
    {
        public string Name { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public double price { get; set; }
        public int CurrencyId { get; set; }

        public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly ILoggedInUserContext _loggedInUserContext;

            public CreateBookingCommandHandler(IApplicationDbContext dbContext, ILoggedInUserContext loggedInUserContext)
            {
                _dbContext = dbContext;
                _loggedInUserContext = loggedInUserContext;
            }

            public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                //Validate 
                var booking = new Booking()
                {
                    Name = request.Name,
                    Status = request.Status,
                    StartDate = request.StartDate,
                    CurrencyId = request.CurrencyId,
                    CreatedBy = _loggedInUserContext.Id
                };
                _dbContext.Bookings.Add(booking);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return booking.Id;
            }
        }
    }
}