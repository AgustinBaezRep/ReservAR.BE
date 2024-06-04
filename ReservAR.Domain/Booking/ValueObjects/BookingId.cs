using ReservAR.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Domain.Booking.ValueObjects
{
    public sealed class BookingId : ValueObject
    {
        public Guid Value { get; set; }

        private BookingId(Guid value)
        {
            Value = value;
        }

        public static BookingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static BookingId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
