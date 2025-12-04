namespace LeesSom.Shared.Models;

public record Score
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public required string GameType { get; init; }
    public int Points { get; init; }
    public int CorrectAnswers { get; init; }
    public int TotalQuestions { get; init; }
    public DateTime PlayedAt { get; init; } = DateTime.UtcNow;
}

public record SaveScoreRequest
{
    public int UserId { get; init; }
    public required string GameType { get; init; }
    public int Points { get; init; }
    public int CorrectAnswers { get; init; }
    public int TotalQuestions { get; init; }
}
