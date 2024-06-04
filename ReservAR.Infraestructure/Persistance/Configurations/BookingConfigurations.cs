using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.Booking;
using ReservAR.Domain.Booking.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations
{
    public class BookingConfigurations : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            ConfigureBookingTable(builder);
            ConfigureBookingItemsTable(builder);
        }

        private void ConfigureBookingItemsTable(EntityTypeBuilder<Booking> builder)
        {
            builder.OwnsMany(m => m.BookingItems, sb =>
            {
                sb.ToTable("BookingItems");

                sb.WithOwner().HasForeignKey("BookingId");

                sb.HasKey("Id", "BookingId");

                sb.Property(m => m.Id)
                    .HasColumnName("BookingItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => BookingItemId.Create(value));

                sb.Property(m => m.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                sb.Property(m => m.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }

        private void ConfigureBookingTable(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BookingId.Create(value));

            builder.Property(m => m.Duration)
                .HasMaxLength(20);
        }
    }
}