using CA.RoadReady.Application.Abstractions.Messaging;

namespace CA.RoadReady.Application.Vehicles.SearchVehicles;

public sealed record SearchVehiclesQuery(DateOnly StartDate,
                                         DateOnly EndDate) : IQuery<IReadOnlyList<VehicleResponse>>;
