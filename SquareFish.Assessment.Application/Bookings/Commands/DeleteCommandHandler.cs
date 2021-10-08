using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.Bookings.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Bookings.FirstOrDefault(x => x.Id == request.Id);
            if (entity == null)
            {
                throw new NotFoundException($"Item Witd {request.Id} is not available in Database!");
            }
            _dbContext.Bookings.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}