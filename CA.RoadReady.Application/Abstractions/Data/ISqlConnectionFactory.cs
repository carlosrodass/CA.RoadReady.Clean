using System.Data;

namespace CA.RoadReady.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{

    IDbConnection CreateConnection();

}
