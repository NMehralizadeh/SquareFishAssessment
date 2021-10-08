using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.Bookings.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILoggedInUserContext _loggedInUserContext;

        public UpdateCommandHandler(IApplicationDbContext dbContext, ILoggedInUserContext loggedInUserContext)
        {
            _dbContext = dbContext;
            _loggedInUserContext = loggedInUserContext;
        }
        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var entity = _dbContext.Bookings.FirstOrDefault(x => x.Id == request.Id);
            if (entity == null)
            {
                throw new NotFoundException($"Booking With Id {request.Id} is not available in Database!");
            }

            if (entity.Status == BookingStatus.Accepted && request.Status != BookingStatus.Accepted)
            {
                throw new BusinessConditionException($"Can not change status of Accepted to other states!");
            }

            entity.Name = request.Name;
            entity.Status = request.Status;
            entity.StartDate = request.StartDate;
            entity.CurrencyId = request.CurrencyId;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = _loggedInUserContext.Id;
            return await _dbContext.SaveChangesAsync();
        }
    }
}