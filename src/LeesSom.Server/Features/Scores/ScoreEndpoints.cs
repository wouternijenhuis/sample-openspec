using LeesSom.Server.Features.Progress;
using LeesSom.Shared.Models;

namespace LeesSom.Server.Features.Scores;

public static class ScoreEndpoints
{
    public static void MapScoreEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/scores").WithTags("Scores");

        group.MapGet("/user/{userId:int}", async (int userId, IScoreRepository repository) =>
            Results.Ok(await repository.GetByUserIdAsync(userId)))
            .WithName("GetScoresByUserId");

        group.MapGet("/top/{gameType}", async (string gameType, IScoreRepository repository, int limit = 10) =>
            Results.Ok(await repository.GetTopScoresAsync(gameType, limit)))
            .WithName("GetTopScores");

        group.MapPost("/", async (SaveScoreRequest request, IScoreRepository scoreRepository, IProgressRepository progressRepository) =>
        {
            var score = await scoreRepository.SaveAsync(request);
            await progressRepository.UpdateProgressAsync(request.UserId, request.GameType, request.CorrectAnswers, request.TotalQuestions);
            return Results.Created($"/api/scores/{score.Id}", score);
        })
        .WithName("SaveScore");
    }
}
