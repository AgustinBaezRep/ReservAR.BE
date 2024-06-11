using ReservAR.Domain.Booking;

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