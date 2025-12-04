using Dapper;
using LeesSom.Server.Infrastructure;
using LeesSom.Shared.Models;

namespace LeesSom.Server.Features.Scores;

public interface IScoreRepository
{
    Task<IEnumerable<Score>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Score>> GetTopScoresAsync(string gameType, int limit = 10);
    Task<Score> SaveAsync(SaveScoreRequest request);
}

public class ScoreRepository : IScoreRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ScoreRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Score>> GetByUserIdAsync(int userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Score>(
            "SELECT * FROM Scores WHERE UserId = @UserId ORDER BY PlayedAt DESC",
            new { UserId = userId });
    }

    public async Task<IEnumerable<Score>> GetTopScoresAsync(string gameType, int limit = 10)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Score>(
            """
            SELECT * FROM Scores 
            WHERE GameType = @GameType 
            ORDER BY Points DESC 
            LIMIT @Limit
            """,
            new { GameType = gameType, Limit = limit });
    }

    public async Task<Score> SaveAsync(SaveScoreRequest request)
    {
        using var connection = _connectionFactory.CreateConnection();
        var id = await connection.ExecuteScalarAsync<int>(
            """
            INSERT INTO Scores (UserId, GameType, Points, CorrectAnswers, TotalQuestions, PlayedAt) 
            VALUES (@UserId, @GameType, @Points, @CorrectAnswers, @TotalQuestions, @PlayedAt);
            SELECT last_insert_rowid();
            """,
            new 
            { 
                request.UserId, 
                request.GameType, 
                request.Points, 
                request.CorrectAnswers, 
                request.TotalQuestions, 
                PlayedAt = DateTime.UtcNow.ToString("O") 
            });

        return await connection.QuerySingleAsync<Score>(
            "SELECT * FROM Scores WHERE Id = @Id", new { Id = id });
    }
}
