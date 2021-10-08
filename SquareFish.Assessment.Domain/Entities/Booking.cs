using System.Collections.Generic;
using System;
namespace SquareFish.Assessment.Domain.Entities
{
    public enum BookingStatus
    {
        New,
        Canceled,
        Accepted
    }

    public class Booking : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public double price { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        
        public ICollection<BookingLeader> BookingLeaders { get; set; }
    }
}