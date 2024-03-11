using CA.RoadReady.Application.Abstractions.Data;
using CA.RoadReady.Application.Abstractions.Messaging;
using CA.RoadReady.Domain.Abstractions;

namespace CA.RoadReady.Application.Vehicles.SearchVehicles;

internal sealed class SearchVehiclesQueryHandler : IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
{

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchVehiclesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(SearchVehiclesQuery request,
                                                                     CancellationToken cancellationToken)
    {

        if (request.StartDate > request.EndDate) { return new List<VehicleResponse>(); }


        using var connection = _sqlConnectionFactory.CreateConnection();

        //TODO: TO Complete

        const string sql = """
            SELECT
                a.Id AS Id
            FROM Vehicles AS v
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM Rentings AS r
                WHERE 
                    b.VehicleId = a.Id
            )
            """;


        throw new NotImplementedException();

    }
}