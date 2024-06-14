using ReservAR.Application.Common.Specifications.BookingSpecifications;
using ReservAR.Domain.Booking;

namespace ReservAR.Application.Common.Interfaces.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking?>> GetTopThreePriceLowerBookings(TopThreePriceLowerSpecification specification, CancellationToken cancellationToken);
        Task<Booking?> GetLowerCostBooking(PriceLowerBookingSpecification specification, CancellationToken cancellationToken);
    }
}
