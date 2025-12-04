using Microsoft.Data.Sqlite;

namespace LeesSom.Server.Infrastructure;

public class DatabaseInitializer
{
    private readonly string _connectionString;

    public DatabaseInitializer(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? "Data Source=leessom.db";
    }

    public async Task InitializeAsync()
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Avatar TEXT,
                CreatedAt TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Scores (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                GameType TEXT NOT NULL,
                Points INTEGER NOT NULL,
                CorrectAnswers INTEGER NOT NULL,
                TotalQuestions INTEGER NOT NULL,
                PlayedAt TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(Id)
            );

            CREATE TABLE IF NOT EXISTS Progress (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                GameType TEXT NOT NULL,
                Level INTEGER NOT NULL DEFAULT 1,
                TotalGamesPlayed INTEGER NOT NULL DEFAULT 0,
                TotalCorrectAnswers INTEGER NOT NULL DEFAULT 0,
                TotalQuestions INTEGER NOT NULL DEFAULT 0,
                LastPlayedAt TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(Id),
                UNIQUE(UserId, GameType)
            );
            """;

        await command.ExecuteNonQueryAsync();
    }
}
