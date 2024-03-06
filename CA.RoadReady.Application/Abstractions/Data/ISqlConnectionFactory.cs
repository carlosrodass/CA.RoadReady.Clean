using System.Data;

namespace CA.RoadReady.Application.Abstractions.Data;

internal interface ISqlConnectionFactory
{

    IDbConnection CreateConnection();

}
