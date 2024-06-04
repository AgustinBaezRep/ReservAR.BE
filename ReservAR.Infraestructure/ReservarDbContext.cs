using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservAR.Domain.Booking;
using ReservAR.Domain.Booking.Entities;
using ReservAR.Domain.User;

namespace ReservAR.Infraestructure
{
    public class ReservarDbContext : IdentityDbContext<User>
    {
        public ReservarDbContext(DbContextOptions<ReservarDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ReservarDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
