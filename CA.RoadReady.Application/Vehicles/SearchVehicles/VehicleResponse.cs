using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Application.Vehicles.SearchVehicles;

public sealed class VehicleResponse
{
    public Guid Id { get; init; }
    public string? Model { get; init; }
    public string? Vin { get; init; }
    public DirectionResponse? Direction { get; init; }
    public decimal Price { get; init; }
    public string? CurrencyType { get; init; }


}
