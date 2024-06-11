using Microsoft.EntityFrameworkCore;
using ReservAR.Application.Helpers.Specifications;
using ReservAR.Application.Helpers.Specifications.BookingSpecifications;
using ReservAR.Application.IRepositories;
using ReservAR.Domain.Booking;

namespace ReservAR.Infraestructure.Persistance.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ReservarDbContext _context;

        public BookingRepository(ReservarDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking?>> GetTopThreePriceLowerBookings(TopThreePriceLowerSpecification specification, CancellationToken cancellationToken)
        {
            return await ApplyBookingSpecification(specification)
                .Take(3)
                .ToListAsync(cancellationToken);
        }

        public async Task<Booking?> GetLowerCostBooking(PriceLowerBookingSpecification specification, CancellationToken cancellationToken)
        {
            return await ApplyBookingSpecification(specification)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private IQueryable<Booking?> ApplyBookingSpecification(Specification<Booking> specification)
        {
            return SpecificationQueryBuilder.GetQuery(_context.Bookings, specification);
        }
    }
}