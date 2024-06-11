using ReservAR.Application.Helpers.Specifications;
using ReservAR.Application.Helpers.Specifications.BookingSpecifications;
using ReservAR.Domain.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Application.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking?>> GetTopThreePriceLowerBookings(TopThreePriceLowerSpecification specification, CancellationToken cancellationToken);
        Task<Booking?> GetLowerCostBooking(PriceLowerBookingSpecification specification, CancellationToken cancellationToken);
    }
}
