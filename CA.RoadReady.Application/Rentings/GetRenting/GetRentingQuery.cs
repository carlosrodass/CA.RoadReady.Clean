using CA.RoadReady.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Application.Rentings.GetRenting
{
    public sealed record GetRentingQuery(Guid RentingId) : IQuery<RentingResponse>;

}
