# Change: Refactor to Vertical Slice Architecture

## Why
The current project uses a horizontal layer architecture (Data/, Endpoints/, Models/) which groups code by technical concern. This makes it harder to understand and modify feature-specific code because related pieces are scattered across multiple folders. Vertical slice architecture organizes code by feature/capability, keeping all related code together, improving maintainability and making it easier to understand what each feature does.

## What Changes
- **BREAKING**: Reorganize server folder structure from layers (Data/, Endpoints/) to features (Features/Users/, Features/Scores/, Features/Progress/)
- **BREAKING**: Reorganize client folder structure from Pages/ to feature-based (Features/Home/, Features/Games/Arithmetic/, Features/Games/Topography/)
- Move shared infrastructure (DatabaseInitializer, DbConnectionFactory) to Infrastructure/ folder
- Each feature folder contains its own endpoints, repository, and models
- Update namespaces to reflect new structure
- Update project.md with vertical slice architecture conventions

## Impact
- Affected specs: `architecture` (new capability)
- Affected code:
  - `LeesSom.Server/Data/` → `LeesSom.Server/Features/` and `LeesSom.Server/Infrastructure/`
  - `LeesSom.Server/Endpoints/` → `LeesSom.Server/Features/`
  - `LeesSom.Client/Pages/` → `LeesSom.Client/Features/`
  - `LeesSom.Shared/Models/` → stays but may be referenced differently
  - `LeesSom.Server/Program.cs` - update service registration and endpoint mapping
