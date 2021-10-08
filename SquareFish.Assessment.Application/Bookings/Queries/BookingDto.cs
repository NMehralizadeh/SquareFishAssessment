using System;
using AutoMapper;
using SquareFish.Assessment.Application.Mappings;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Application.Bookings.Queries
{
    public class BookingDto : IMapFrom<Booking>
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public double price { get; set; }
        public int CurrencyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingDto>()
            .ForMember(d => d.BookingId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
