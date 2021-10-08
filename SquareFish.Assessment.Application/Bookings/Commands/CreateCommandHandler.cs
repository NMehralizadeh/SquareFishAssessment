using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.Bookings.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILoggedInUserContext _loggedInUserContext;

        public CreateCommandHandler(IApplicationDbContext dbContext, ILoggedInUserContext loggedInUserContext)
        {
            _dbContext = dbContext;
            _loggedInUserContext = loggedInUserContext;
        }

        public async Task<int> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            //Validate 
            await _dbContext.Bookings.AddAsync(new Booking()
            {
                CreatedBy = _loggedInUserContext.Id,
                Name = request.Name,
                Status = request.Status,
                StartDate = request.StartDate,
                CurrencyId = request.CurrencyId
            },cancellationToken);
            return await _dbContext.SaveChangesAsync();
        }
    }
}