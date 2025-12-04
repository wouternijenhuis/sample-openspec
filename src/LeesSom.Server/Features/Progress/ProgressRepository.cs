using Dapper;
using LeesSom.Server.Infrastructure;
using LeesSom.Shared.Models;

namespace LeesSom.Server.Features.Progress;

public interface IProgressRepository
{
    Task<IEnumerable<UserProgress>> GetByUserIdAsync(int userId);
    Task UpdateProgressAsync(int userId, string gameType, int correctAnswers, int totalQuestions);
}

public class ProgressRepository : IProgressRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ProgressRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<UserProgress>> GetByUserIdAsync(int userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<UserProgress>(
            """
            SELECT 
                GameType,
                Level,
                TotalGamesPlayed,
                CASE 
                    WHEN TotalQuestions > 0 
                    THEN CAST(TotalCorrectAnswers AS REAL) / TotalQuestions * 100 
                    ELSE 0 
                END as SuccessRate
            FROM Progress 
            WHERE UserId = @UserId
            """,
            new { UserId = userId });
    }

    public async Task UpdateProgressAsync(int userId, string gameType, int correctAnswers, int totalQuestions)
    {
        using var connection = _connectionFactory.CreateConnection();
        
        // Try to update existing progress
        var updated = await connection.ExecuteAsync(
            """
            UPDATE Progress 
            SET TotalGamesPlayed = TotalGamesPlayed + 1,
                TotalCorrectAnswers = TotalCorrectAnswers + @CorrectAnswers,
                TotalQuestions = TotalQuestions + @TotalQuestions,
                Level = CASE 
                    WHEN (TotalCorrectAnswers + @CorrectAnswers) * 100.0 / (TotalQuestions + @TotalQuestions) >= 80 
                        AND TotalGamesPlayed + 1 >= Level * 5
                    THEN Level + 1 
                    ELSE Level 
                END,
                LastPlayedAt = @LastPlayedAt
            WHERE UserId = @UserId AND GameType = @GameType
            """,
            new 
            { 
                UserId = userId, 
                GameType = gameType, 
                CorrectAnswers = correctAnswers, 
                TotalQuestions = totalQuestions,
                LastPlayedAt = DateTime.UtcNow.ToString("O")
            });

        // If no row was updated, insert a new record
        if (updated == 0)
        {
            await connection.ExecuteAsync(
                """
                INSERT INTO Progress (UserId, GameType, Level, TotalGamesPlayed, TotalCorrectAnswers, TotalQuestions, LastPlayedAt)
                VALUES (@UserId, @GameType, 1, 1, @CorrectAnswers, @TotalQuestions, @LastPlayedAt)
                """,
                new 
                { 
                    UserId = userId, 
                    GameType = gameType, 
                    CorrectAnswers = correctAnswers, 
                    TotalQuestions = totalQuestions,
                    LastPlayedAt = DateTime.UtcNow.ToString("O")
                });
        }
    }
}
