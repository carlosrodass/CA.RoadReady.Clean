using CA.RoadReady.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Rentings.Events
{
    public sealed record BookingRejectedDomainEvent(Guid RentingId) : IDomainEvent;
}
