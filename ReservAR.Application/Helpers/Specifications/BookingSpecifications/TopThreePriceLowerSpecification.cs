using ReservAR.Domain.Booking;

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
