using ReservAR.Domain.Booking.Entities;
using ReservAR.Domain.Booking.ValueObjects;
using ReservAR.Domain.Common.Models;

namespace ReservAR.Domain.Booking
{
    public sealed class Booking : AggregateRoot<BookingId>
    {
        readonly List<BookingItem> _bookingItem = new List<BookingItem>();

        public string Duration { get; private set; }
        public bool Fixed { get; private set; }
        public decimal Price { get; private set; }
        public IReadOnlyList<BookingItem> BookingItems => _bookingItem.ToList();

        public Booking() { }

        private Booking(BookingId id, string duration, bool fixedPrice, decimal price)
        {
            Duration = duration;
            Fixed = fixedPrice;
            Price = price;
        }

        public static Booking Create(string duration, bool fixedPrice, decimal price)
        {
            return new(BookingId.CreateUnique(), duration, fixedPrice, price);
        }
    }
}
