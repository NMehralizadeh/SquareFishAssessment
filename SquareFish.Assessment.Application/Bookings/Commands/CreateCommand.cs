using System;
using MediatR;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.Bookings.Commands
{
    public class CreateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public double price { get; set; }
        public int CurrencyId { get; set; }
    }
}