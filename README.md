# LeesSom 🎮

A fun educational game application for children to practice arithmetic and geography skills!

## 🎯 Features

- **Arithmetic Game** 🔢 - Practice addition, subtraction, multiplication, and division
- **Topography Game** 🌍 - Learn world capitals, countries, and geography facts
- **Score Tracking** ⭐ - Track progress and celebrate achievements
- **Fun Animations** 🎉 - Bouncing emojis and celebratory effects throughout

## 🏗️ Project Structure

```
├── src/                        # Source code
│   ├── LeesSom.Client/         # Blazor WebAssembly frontend
│   ├── LeesSom.Server/         # ASP.NET Core API backend
│   └── LeesSom.Shared/         # Shared models and DTOs
├── docs/                       # Documentation
├── openspec/                   # Specifications (OpenSpec)
│   ├── project.md              # Project conventions
│   ├── specs/                  # Current specifications
│   └── changes/                # Change proposals
└── .github/                    # GitHub workflows
```

## 🛠️ Tech Stack

- **.NET 10.0** (Preview)
- **Blazor WebAssembly** - Interactive web UI
- **ASP.NET Core Minimal APIs** - Backend services
- **SQLite + Dapper** - Data persistence
- **Vertical Slice Architecture** - Feature-organized codebase

## 🚀 Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Running the Application

```bash
# Navigate to the server project
cd src/LeesSom.Server

# Run the application
dotnet run
```

The application will be available at `http://localhost:5230`

## 📁 Architecture

This project follows **Vertical Slice Architecture**:

- **Features/** folders organize code by capability, not layer
- Each feature contains its own endpoints, repositories, and components
- Shared infrastructure in **Infrastructure/** folder

## 📝 Development

This project uses [OpenSpec](openspec/AGENTS.md) for spec-driven development:

1. Check existing specs: `openspec list --specs`
2. Create change proposals for new features
3. Implement according to specifications

## 📄 License

See [LICENSE](LICENSE) for details.