using ReservAR.Application.Common.Specifications;
using ReservAR.Domain.Booking;

namespace ReservAR.Application.Common.Specifications.BookingSpecifications
{
    public class TopThreePriceLowerSpecification : Specification<Booking>
    {
        public TopThreePriceLowerSpecification()
        {
            AddOrderBy(x => x.Price);
        }
    }
}
