## Context
The project currently uses horizontal layer architecture where code is organized by technical concern (Data, Endpoints, Models). This is a common pattern but has drawbacks:
- Related code is scattered across folders
- Adding a new feature requires touching multiple folders
- Hard to understand the full scope of a feature

Vertical slice architecture organizes code by feature, keeping all related pieces together.

## Goals / Non-Goals
- **Goals:**
  - Organize code by feature/capability for better cohesion
  - Make it easier to understand what each feature does
  - Simplify adding new features (create one folder with everything)
  - Maintain existing functionality without behavioral changes

- **Non-Goals:**
  - Adding MediatR or CQRS patterns (keep it simple)
  - Changing the database schema
  - Modifying the Shared project structure (models stay shared)

## Decisions

### Decision: Feature folder structure
Each feature gets its own folder containing all related code:
```
Features/
├── Users/
│   ├── UserEndpoints.cs      # API routes
│   └── UserRepository.cs     # Data access
├── Scores/
│   ├── ScoreEndpoints.cs
│   └── ScoreRepository.cs
└── Progress/
    ├── ProgressEndpoints.cs
    └── ProgressRepository.cs
```

**Why**: Keeps all feature code together, making it easy to understand and modify.

### Decision: Shared infrastructure in Infrastructure/
Database initialization and connection factory go in Infrastructure/ because they're cross-cutting concerns used by all features.

```
Infrastructure/
├── DatabaseInitializer.cs
└── DbConnectionFactory.cs
```

**Why**: Avoids duplication while keeping feature folders focused.

### Decision: Client feature organization
Group Blazor pages by feature area:
```
Features/
├── Home/
│   └── Home.razor
├── Games/
│   ├── Arithmetic/
│   │   └── ArithmeticGame.razor
│   └── Topography/
│       └── TopographyGame.razor
├── Demo/
│   ├── Counter.razor
│   └── Weather.razor
└── Shared/
    └── NotFound.razor
```

**Why**: Mirrors server structure, groups related UI components.

### Decision: Keep models in Shared project
Models stay in `LeesSom.Shared/Models/` because they're used by both client and server.

**Why**: Shared models need to be in a shared assembly.

### Alternatives Considered
1. **Full CQRS with MediatR**: Too complex for this project size
2. **Feature folders with nested Models/**: Would duplicate shared models
3. **Micro-frontends**: Overkill for a simple app

## Risks / Trade-offs
- **Risk**: Breaking existing references → Mitigation: Update all using statements and verify with build
- **Risk**: Unfamiliar structure for new developers → Mitigation: Document conventions in project.md

## Migration Plan
1. Create new folder structure
2. Move files one feature at a time
3. Update namespaces and using statements
4. Update Program.cs registrations
5. Delete old folders
6. Build and test

## Open Questions
- None - straightforward refactoring
