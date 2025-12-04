namespace LeesSom.Shared.Models;

public record User
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Avatar { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public record CreateUserRequest
{
    public required string Name { get; init; }
    public string? Avatar { get; init; }
}
