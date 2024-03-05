using CA.RoadReady.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Vehicles
{
    public static class VehicleErrors
    {
        public static readonly Error NotFound = new Error(
            "Vehicle.NotFound",
            "Vehicle not found"
            );

    }
}
