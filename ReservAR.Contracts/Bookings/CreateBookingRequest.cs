using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Contracts.Bookings
{
    public record CreateBookingRequest(string description, decimal price);
}
