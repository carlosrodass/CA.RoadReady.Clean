using CA.RoadReady.Application.Abstractions.Data;
using Npgsql;
using System.Data;

namespace CA.RoadReady.Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{

    private readonly string _ConnectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _ConnectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {

        var connection = new NpgsqlConnection(_ConnectionString);
        connection.Open();

        return connection;
    }
}
