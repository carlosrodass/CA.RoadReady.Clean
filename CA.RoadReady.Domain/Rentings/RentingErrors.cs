using CA.RoadReady.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Rentings
{
    public static class RentingErrors
    {

        public static readonly Error NotFound = new Error(
            "Booking.Found",
            "Booking with giving Id was not found"
        );

        public static readonly Error Overlap = new Error(
            "Booking.Overlap",
            "Booking is being used by two or more client at same time"
        );

        public static readonly Error NotReserved = new Error(
            "Booking.NotReserved",
            "Booking is not reserved"
        );

        public static readonly Error NotConfirmed = new Error(
            "Booking.NotConfirmed",
            "Booking not confirmed"
        );

        public static readonly Error AlreadyStarted = new Error(
            "Booking.AlreadyStarted",
            "Booking Already Started"
        );

    }
}
