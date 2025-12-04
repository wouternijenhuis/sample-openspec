namespace LeesSom.Server.Features.Progress;

public static class ProgressEndpoints
{
    public static void MapProgressEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/progress").WithTags("Progress");

        group.MapGet("/user/{userId:int}", async (int userId, IProgressRepository repository) =>
            Results.Ok(await repository.GetByUserIdAsync(userId)))
            .WithName("GetProgressByUserId");
    }
}
