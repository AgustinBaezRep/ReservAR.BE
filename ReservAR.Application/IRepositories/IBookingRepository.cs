using ReservAR.Application.Helpers.Specifications.BookingSpecifications;
using ReservAR.Domain.Booking;

namespace ReservAR.Application.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking?>> GetTopThreePriceLowerBookings(TopThreePriceLowerSpecification specification, CancellationToken cancellationToken);
        Task<Booking?> GetLowerCostBooking(PriceLowerBookingSpecification specification, CancellationToken cancellationToken);
    }
}
