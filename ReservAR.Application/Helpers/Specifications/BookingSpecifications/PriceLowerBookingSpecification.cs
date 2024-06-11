using ReservAR.Domain.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Application.Helpers.Specifications.BookingSpecifications
{
    public class PriceLowerBookingSpecification : Specification<Booking>
    {
        public PriceLowerBookingSpecification() : base(x => x.Price < 5000)
        {
            AddOrderBy(x => x.Duration);
        }
    }
}