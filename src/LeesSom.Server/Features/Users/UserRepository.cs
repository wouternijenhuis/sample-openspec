using Dapper;
using LeesSom.Server.Infrastructure;
using LeesSom.Shared.Models;

namespace LeesSom.Server.Features.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(CreateUserRequest request);
}

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UserRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<User>(
            "SELECT * FROM Users WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<User>("SELECT * FROM Users ORDER BY Name");
    }

    public async Task<User> CreateAsync(CreateUserRequest request)
    {
        using var connection = _connectionFactory.CreateConnection();
        var id = await connection.ExecuteScalarAsync<int>(
            """
            INSERT INTO Users (Name, Avatar, CreatedAt) 
            VALUES (@Name, @Avatar, @CreatedAt);
            SELECT last_insert_rowid();
            """,
            new { request.Name, request.Avatar, CreatedAt = DateTime.UtcNow.ToString("O") });

        return (await GetByIdAsync(id))!;
    }
}
