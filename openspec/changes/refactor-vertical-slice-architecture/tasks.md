## 1. Server Infrastructure Setup
- [x] 1.1 Create Infrastructure/ folder and move DatabaseInitializer.cs
- [x] 1.2 Create DbConnectionFactory for shared database connection logic
- [x] 1.3 Update Program.cs to reference new infrastructure location

## 2. Server Feature: Users
- [x] 2.1 Create Features/Users/ folder structure
- [x] 2.2 Move UserRepository to Features/Users/UserRepository.cs
- [x] 2.3 Move UserEndpoints to Features/Users/UserEndpoints.cs
- [x] 2.4 Update namespaces to LeesSom.Server.Features.Users

## 3. Server Feature: Scores
- [x] 3.1 Create Features/Scores/ folder structure
- [x] 3.2 Move ScoreRepository to Features/Scores/ScoreRepository.cs
- [x] 3.3 Move ScoreEndpoints to Features/Scores/ScoreEndpoints.cs
- [x] 3.4 Update namespaces to LeesSom.Server.Features.Scores

## 4. Server Feature: Progress
- [x] 4.1 Create Features/Progress/ folder structure
- [x] 4.2 Move ProgressRepository to Features/Progress/ProgressRepository.cs
- [x] 4.3 Move ProgressEndpoints to Features/Progress/ProgressEndpoints.cs
- [x] 4.4 Update namespaces to LeesSom.Server.Features.Progress

## 5. Client Feature Reorganization
- [x] 5.1 Create Features/Home/ folder and move Home.razor
- [x] 5.2 Create Features/Games/Arithmetic/ folder and move ArithmeticGame.razor
- [x] 5.3 Create Features/Games/Topography/ folder and move TopographyGame.razor
- [x] 5.4 Move Counter.razor, Weather.razor to Features/Demo/ (sample pages)
- [x] 5.5 Move NotFound.razor to Features/Shared/
- [x] 5.6 Update _Imports.razor with new namespaces

## 6. Cleanup and Documentation
- [x] 6.1 Delete old Data/ and Endpoints/ folders (server)
- [x] 6.2 Delete old Pages/ folder (client)
- [x] 6.3 Update Program.cs with feature-based service registration
- [x] 6.4 Update project.md with vertical slice architecture conventions
- [x] 6.5 Build and verify no compilation errors
