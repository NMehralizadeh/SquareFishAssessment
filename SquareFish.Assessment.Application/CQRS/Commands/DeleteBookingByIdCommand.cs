using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;

namespace SquareFish.Assessment.Application.CQRS.Commands
{
    public class DeleteBookingByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteBookingByIdCommandHandler : IRequestHandler<DeleteBookingByIdCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteBookingByIdCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<int> Handle(DeleteBookingByIdCommand request, CancellationToken cancellationToken)
            {
                var booking = await _dbContext.Bookings.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (booking == null)
                {
                    throw new NotFoundException($"Item With {request.Id} is not available in Database!");
                }
                _dbContext.Bookings.Remove(booking);
                await _dbContext.SaveChangesAsync();
                return booking.Id;
            }
        }
    }
}