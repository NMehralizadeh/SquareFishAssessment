using System;
using System.Collections.Generic;

namespace SquareFish.Assessment.Domain.Entities
{
    public class Leader : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        public ICollection<BookingLeader> BookingLeaders { get; set; }
    }
}