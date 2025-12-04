using LeesSom.Server.Infrastructure;
using LeesSom.Server.Features.Users;
using LeesSom.Server.Features.Scores;
using LeesSom.Server.Features.Progress;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();

// Register infrastructure services
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

// Register feature services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();

var app = builder.Build();

// Initialize database
var dbInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await dbInitializer.InitializeAsync();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

// Serve Blazor WebAssembly files
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

// Map API endpoints
app.MapUserEndpoints();
app.MapScoreEndpoints();
app.MapProgressEndpoints();

// Fallback to index.html for client-side routing
app.MapFallbackToFile("index.html");

app.Run();
