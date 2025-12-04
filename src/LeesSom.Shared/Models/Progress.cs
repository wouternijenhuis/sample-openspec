namespace LeesSom.Shared.Models;

public record Progress
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public required string GameType { get; init; }
    public int Level { get; init; }
    public int TotalGamesPlayed { get; init; }
    public int TotalCorrectAnswers { get; init; }
    public int TotalQuestions { get; init; }
    public DateTime LastPlayedAt { get; init; }
}

public record UserProgress
{
    public required string GameType { get; init; }
    public int Level { get; init; }
    public int TotalGamesPlayed { get; init; }
    public double SuccessRate { get; init; }
}
