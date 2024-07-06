using ReservAR.Domain.Booking.ValueObjects;
using ReservAR.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Domain.Booking.Entities
{
    public sealed class BookingItem : EntityBase<BookingItemId>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public BookingItem() : base() { }

        private BookingItem(BookingItemId id, string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
