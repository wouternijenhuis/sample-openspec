using LeesSom.Shared.Models;

namespace LeesSom.Server.Features.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users").WithTags("Users");

        group.MapGet("/", async (IUserRepository repository) =>
            Results.Ok(await repository.GetAllAsync()))
            .WithName("GetAllUsers");

        group.MapGet("/{id:int}", async (int id, IUserRepository repository) =>
        {
            var user = await repository.GetByIdAsync(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        })
        .WithName("GetUserById");

        group.MapPost("/", async (CreateUserRequest request, IUserRepository repository) =>
        {
            var user = await repository.CreateAsync(request);
            return Results.Created($"/api/users/{user.Id}", user);
        })
        .WithName("CreateUser");
    }
}
