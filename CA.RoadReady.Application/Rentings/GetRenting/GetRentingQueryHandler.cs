using CA.RoadReady.Application.Abstractions.Data;
using CA.RoadReady.Application.Abstractions.Messaging;
using CA.RoadReady.Domain.Abstractions;
using Dapper;

namespace CA.RoadReady.Application.Rentings.GetRenting
{
    internal sealed class GetRentingQueryHandler : IQueryHandler<GetRentingQuery, RentingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRentingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<RentingResponse>> Handle(
            GetRentingQuery request,
            CancellationToken cancellationToken)
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            //TODO: Complete instruction
            var sql = """ 
                SELECT 
                   *
                FROM Rentings
                WHERE id=@RentingId 
            """;


            var renting = await connection.QueryFirstOrDefaultAsync<RentingResponse>(
                 sql,
                 new
                 {
                     request.RentingId
                 }
             );

            //Check before

            return renting;
        }
    }

}
