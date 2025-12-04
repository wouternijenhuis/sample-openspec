# LeesSom Architecture

## Overview

LeesSom is an educational game application built with a modern .NET stack, following Vertical Slice Architecture principles.

## System Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                        Browser                               │
│  ┌─────────────────────────────────────────────────────────┐│
│  │              Blazor WebAssembly Client                  ││
│  │  ┌──────────┐  ┌──────────┐  ┌──────────┐              ││
│  │  │   Home   │  │Arithmetic│  │Topography│              ││
│  │  │ Feature  │  │  Game    │  │   Game   │              ││
│  │  └──────────┘  └──────────┘  └──────────┘              ││
│  └─────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
                              │
                              │ HTTP/JSON
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                    ASP.NET Core Server                       │
│  ┌──────────────────────────────────────────────────────────┐│
│  │                   Minimal APIs                           ││
│  │  ┌──────────┐  ┌──────────┐  ┌──────────┐               ││
│  │  │  Users   │  │  Scores  │  │ Progress │               ││
│  │  │ Feature  │  │ Feature  │  │ Feature  │               ││
│  │  └──────────┘  └──────────┘  └──────────┘               ││
│  └──────────────────────────────────────────────────────────┘│
│                              │                               │
│                              ▼                               │
│  ┌──────────────────────────────────────────────────────────┐│
│  │                Infrastructure                            ││
│  │  ┌────────────────────┐  ┌────────────────────┐          ││
│  │  │ DbConnectionFactory│  │ DatabaseInitializer│          ││
│  │  └────────────────────┘  └────────────────────┘          ││
│  └──────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
                    ┌──────────────────┐
                    │     SQLite       │
                    │    Database      │
                    └──────────────────┘
```

## Project Structure

### Client (LeesSom.Client)

Blazor WebAssembly frontend organized by features:

```
Features/
├── Home/                   # Landing page
│   └── Home.razor
├── Games/
│   ├── Arithmetic/         # Math game
│   │   └── ArithmeticGame.razor
│   └── Topography/         # Geography game
│       └── TopographyGame.razor
├── Demo/                   # Demo/sample pages
│   ├── Counter.razor
│   └── Weather.razor
└── Shared/                 # Shared components
    └── NotFound.razor
```

### Server (LeesSom.Server)

ASP.NET Core Minimal APIs organized by features:

```
Features/
├── Users/
│   ├── UserEndpoints.cs
│   └── UserRepository.cs
├── Scores/
│   ├── ScoreEndpoints.cs
│   └── ScoreRepository.cs
└── Progress/
    ├── ProgressEndpoints.cs
    └── ProgressRepository.cs

Infrastructure/
├── DbConnectionFactory.cs
└── DatabaseInitializer.cs
```

### Shared (LeesSom.Shared)

Common models and DTOs:

```
Models/
├── User.cs
├── Score.cs
├── Progress.cs
└── GameTypes.cs
```

## Design Principles

### Vertical Slice Architecture

- **Feature Cohesion**: Related code lives together
- **Low Coupling**: Features are independent
- **Easy Navigation**: Find all related code in one place
- **Scalable**: Add new features without touching existing ones

### Simplicity First

- Single-file implementations where appropriate
- Minimal abstractions
- SQLite for simple persistence
- Dapper for lightweight data access

## Data Flow

1. User interacts with Blazor component
2. Component calls HTTP API endpoint
3. Endpoint delegates to repository
4. Repository executes SQL via Dapper
5. Results flow back up the chain

## Key Technologies

| Layer | Technology |
|-------|------------|
| Frontend | Blazor WebAssembly |
| Backend | ASP.NET Core Minimal APIs |
| Database | SQLite |
| ORM | Dapper |
| Styling | CSS with animations |
