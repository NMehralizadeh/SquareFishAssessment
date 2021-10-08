using MediatR;

namespace SquareFish.Assessment.Application.Bookings.Commands
{
    public class DeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}