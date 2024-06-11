using ReservAR.Domain.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Application.Helpers.Specifications.BookingSpecifications
{
    public class TopThreePriceLowerSpecification : Specification<Booking>
    {
        public TopThreePriceLowerSpecification()
        {
            AddOrderBy(x => x.Price);
        }
    }
}
