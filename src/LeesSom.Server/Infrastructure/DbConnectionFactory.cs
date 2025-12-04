using System.Data;
using Microsoft.Data.Sqlite;

namespace LeesSom.Server.Infrastructure;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? "Data Source=leessom.db";
    }

    public IDbConnection CreateConnection() => new SqliteConnection(_connectionString);
}
