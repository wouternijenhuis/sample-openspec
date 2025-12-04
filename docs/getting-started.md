# Getting Started with LeesSom

This guide will help you set up and run the LeesSom application locally.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (Preview)
- A code editor (VS Code recommended)

## Quick Start

### 1. Clone the Repository

```bash
git clone https://github.com/wouternijenhuis/sample-openspec.git
cd sample-openspec
```

### 2. Run the Application

```bash
cd src/LeesSom.Server
dotnet run
```

### 3. Open in Browser

Navigate to `http://localhost:5230` to see the application.

## Project Layout

```
src/
├── LeesSom.Client/     # Blazor WebAssembly frontend
├── LeesSom.Server/     # ASP.NET Core backend
├── LeesSom.Shared/     # Shared models
└── LeesSom.sln         # Solution file
```

## Development Workflow

### Building

```bash
cd src
dotnet build
```

### Running Tests

```bash
dotnet test
```

### Hot Reload

The application supports hot reload for rapid development:

```bash
dotnet watch run
```

## Configuration

### Server Configuration

Configuration files are in `src/LeesSom.Server/`:

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development overrides

### Database

SQLite database is automatically created on first run at `leessom.db`.

## Troubleshooting

### Port Already in Use

If port 5230 is in use, modify `src/LeesSom.Server/Properties/launchSettings.json`.

### Build Errors

Ensure you have .NET 10.0 SDK installed:

```bash
dotnet --version
```

## Next Steps

- Explore the [Architecture](architecture.md) documentation
- Check [OpenSpec](../openspec/AGENTS.md) for spec-driven development
- See active changes in `openspec/changes/`
