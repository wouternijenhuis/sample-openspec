# Project Context

## Purpose
**LeesSom** is an educational web application designed for children to practice and improve their learning through fun, interactive games. The application currently features:
- **Arithmetic Game**: Practice math skills with addition, subtraction, multiplication, and division problems
- **Topography Game**: Learn geography through questions about countries, capitals, oceans, and landmarks

The goal is to make learning engaging and accessible, tracking user progress and scores to encourage continued improvement.

## Tech Stack
- **Framework**: .NET 10.0 (Preview)
- **Frontend**: Blazor WebAssembly (client-side SPA)
- **Backend**: ASP.NET Core Minimal APIs
- **Database**: SQLite with Dapper ORM
- **Shared Models**: Separate shared library for DTOs and models
- **API Documentation**: OpenAPI/Swagger (development only)

### Project Structure (Vertical Slice Architecture)
The project uses **vertical slice architecture** where code is organized by feature rather than by technical layer. Each feature contains all related code (endpoints, repositories, UI components) in one place.

```
LeesSom/
├── LeesSom.Client/              # Blazor WebAssembly frontend
│   ├── Features/                # Feature-organized components
│   │   ├── Home/                # Home page feature
│   │   │   └── Home.razor
│   │   ├── Games/               # Game features
│   │   │   ├── Arithmetic/
│   │   │   │   └── ArithmeticGame.razor
│   │   │   └── Topography/
│   │   │       └── TopographyGame.razor
│   │   ├── Demo/                # Demo/sample components
│   │   │   ├── Counter.razor
│   │   │   └── Weather.razor
│   │   └── Shared/              # Shared UI components
│   │       └── NotFound.razor
│   ├── Layout/                  # Layout components (MainLayout, NavMenu)
│   └── wwwroot/                 # Static assets (CSS, index.html)
├── LeesSom.Server/              # ASP.NET Core backend
│   ├── Features/                # Feature-organized backend code
│   │   ├── Users/               # User management feature
│   │   │   ├── UserEndpoints.cs
│   │   │   └── UserRepository.cs
│   │   ├── Scores/              # Score tracking feature
│   │   │   ├── ScoreEndpoints.cs
│   │   │   └── ScoreRepository.cs
│   │   └── Progress/            # Progress tracking feature
│   │       ├── ProgressEndpoints.cs
│   │       └── ProgressRepository.cs
│   └── Infrastructure/          # Cross-cutting concerns
│       ├── DatabaseInitializer.cs
│       └── DbConnectionFactory.cs
└── LeesSom.Shared/              # Shared models and DTOs
    └── Models/                  # User, Score, Progress, GameTypes
```

## Project Conventions

### Code Style
- **C# Version**: Latest (with nullable reference types enabled)
- **Naming**: PascalCase for types/methods/properties, camelCase for local variables, underscore prefix for private fields (`_random`)
- **Records**: Use `record` types for immutable DTOs and models
- **Required Properties**: Use `required` modifier for mandatory properties
- **Init-only Properties**: Use `init` accessors for immutable properties
- **Implicit Usings**: Enabled project-wide
- **Nullable Reference Types**: Enabled project-wide

### Architecture Patterns
- **Vertical Slice Architecture**: Code organized by feature, not by technical layer
  - Each feature folder contains all related code (endpoints, repositories, UI)
  - Cross-cutting concerns go in `Infrastructure/`
  - Shared models stay in `LeesSom.Shared/Models/`
- **Feature Folder Naming**:
  - Server: `Features/[FeatureName]/` (e.g., `Features/Users/`)
  - Client: `Features/[FeatureName]/` or `Features/[Category]/[FeatureName]/` (e.g., `Features/Games/Arithmetic/`)
- **Namespace Conventions**:
  - Server features: `LeesSom.Server.Features.[FeatureName]`
  - Client features: `LeesSom.Client.Features.[FeatureName]`
  - Infrastructure: `LeesSom.Server.Infrastructure`
- **Repository Pattern**: Database access abstracted through interfaces (`IUserRepository`, `IScoreRepository`, `IProgressRepository`)
- **DbConnectionFactory**: Centralized database connection creation in `Infrastructure/`
- **Dependency Injection**: Repositories registered as scoped services, infrastructure as singleton
- **Minimal APIs**: Endpoint groups organized by feature with route groups (`/api/users`, `/api/scores`, `/api/progress`)
- **Blazor Components**: Single-file components with `@code` blocks for logic
- **Component Injection**: Use `[Inject]` attribute with `default!` for injected services

### Testing Strategy
- Tests should cover game logic, repository operations, and API endpoints
- Use xUnit for unit testing (standard .NET testing framework)
- Mock repositories when testing endpoint logic

### Git Workflow
- Feature branches for new functionality
- Main branch should always be deployable
- Use descriptive commit messages

## Domain Context
- **Target Audience**: Children (elementary school age)
- **Game Types**: Defined as string constants in `GameTypes.cs` (Arithmetic, Topography)
- **Scoring**: Track correct answers, total questions, and points per game session
- **Progress**: Track level, total games played, and success rate per user per game type
- **User Experience**: Colorful, emoji-rich UI designed to be engaging for children

### Game Mechanics
- **Arithmetic**: Random problems with 4 multiple-choice answers, numbers 1-12, all four operations
- **Topography**: Pre-defined question bank with capitals, geography facts, 4 multiple-choice answers
- **Session Length**: 10 questions per game session
- **Feedback**: Immediate visual feedback with emojis and color coding

## Important Constraints
- **Child-Friendly**: All content must be appropriate for children
- **Offline-First**: Games should work with minimal server interaction during gameplay
- **Accessibility**: UI should be easy to read and interact with
- **No Authentication**: Currently no user authentication (simple user selection)
- **Local Database**: SQLite database stored locally (not cloud-hosted)

## External Dependencies
- **Microsoft.AspNetCore.Components.WebAssembly**: Blazor WASM runtime
- **Microsoft.Data.Sqlite**: SQLite database driver
- **Dapper**: Lightweight ORM for database queries
- **Bootstrap**: CSS framework for styling (in wwwroot/lib)
