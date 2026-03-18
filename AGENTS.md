# GRG-CS Agent Guidelines

This repository contains .NET 8.0 projects for educational purposes (German school projects). All code comments, documentation, and user-facing text are in German.

## Project Structure

```
GRG-CS/
├── 2023_Webserver/        # ASP.NET Core MVC web application
├── 2023_Mastermind/       # Console game project
├── 2025_Backend_SQLite_Partials/  # EF Core with SQLite, scaffolded models
├── 2025_Blazor/           # Blazor Server application
├── 2025_WCF_Pokemon_proxy/# WCF service proxy
└── 3ahwii/                # Fraction calculator with xUnit tests
```

## Build/Test Commands

### Solution Level

- `dotnet build` - Build entire solution
- `dotnet test` - Run all tests in solution
- `dotnet test --filter "FullyQualifiedName~MethodName"` - Run specific test by method name
- `dotnet test --filter "FullyQualifiedName~BruchTests"` - Run all tests in a specific test class
- `dotnet test path/to/TestProject.csproj` - Run tests in specific project

### Single Project

- `dotnet build path/to/Project.csproj` - Build single project
- `dotnet run --project path/to/Project.csproj` - Run console/Web app
- `dotnet run --project path/to/Project.csproj -- arg1 arg2` - Run with command-line arguments

## Code Style Guidelines

### Framework & Tools

- Target Framework: .NET 8.0
- Testing: xUnit (with Microsoft.NET.Test.Sdk)
- EF Core: Entity Framework Core with SQLite provider
- Build: `dotnet build` / `dotnet test`

### Naming Conventions

- **Classes**: PascalCase (e.g., `Bruch`, `QuestionController`, `QuestionIndexViewModel`)
- **Methods**: PascalCase, descriptive German names (e.g., `Addiere`, `Kürze`, `ParseBruch`)
- **Properties**: PascalCase (e.g., `CorrectAnswerId`, `Stecker`, `IncrementAmount`)
- **Private fields**: Underscore prefix (e.g., `_ganz`, `_nenner`, `_context`, `_logger`)
- **Parameters**: camelCase (e.g., `bruchtext`, `plaetze`, `pageSize`)
- **Constants**: PascalCase for readonly properties

### Namespace & File Structure

- File-scoped namespaces: `namespace BruchName;` or `namespace quiz.Models;`
- One class per file (matching filename)
- Folder structure mirrors namespace structure
- Test projects: `ProjectNameTest` folder, `ProjectNameTests` class

### Language Features

- **ImplicitUsings**: Enabled (avoid redundant using statements)
- **Nullable Reference Types**: Enabled (`<Nullable>enable</Nullable>`)
- **Null-forgiving operator**: Use `null!` for non-nullable properties initialized by EF Core or DI
- **Brace placement**: No newline before open brace (`csharp_new_line_before_open_brace = none`)
- **String interpolation**: Use `$"{variable}"` format
- **Type inference**: Use `var` for local variables when type is obvious
- **Pattern matching**: Use modern patterns (e.g., `is < 1 or > 100`, `is null`)

### Class Design

- **Accessibility**: Public for API classes, private for implementation helpers
- **Sealed**: Mark controllers as `sealed` when not intended for inheritance
- **Constructors**: Public with parameter validation using `ArgumentException`; private overloads for internal use
- **Partial classes**: Use for EF Core models scaffolded from database
- **Properties**: Auto-implemented when possible, virtual for navigation properties
- **Private helper methods**: Extract complex logic into private methods (e.g., `Kürze()`, `ParseBruch()`)

### Dependency Injection

- Constructor injection for services (e.g., `ILogger<T>`, `DbContext`)
- Register services in `Program.cs` with `builder.Services.Add...()`
- Use `readonly` for injected services

### LINQ & Method Chaining

- Chain methods fluently for readability
- Use `var query = ...` for query definitions, execute with `ToListAsync()` etc.
- Common pattern: `.AsNoTracking().Include().OrderBy().Skip().Take()`

### ASP.NET Core Controllers

- Namespace: `namespace ProjectName.Controllers;`
- Inherit from `Controller` or `ControllerBase`
- Use `[HttpGet]`, `[HttpPost]` attributes for actions
- Return `IActionResult` or `async Task<IActionResult>`
- Log information with structured logging: `_logger.LogInformation("Message {Param}", value);`
- Validate pagination parameters: `page = page < 1 ? 1 : page;`

### ViewModels

- Create ViewModels in `Models/ViewModels/` for complex view data
- Name pattern: `[Entity]IndexViewModel` for list views
- Include pagination properties: `Items`, `TotalCount`, `Page`, `PageSize`

### Entity Framework Core

- Use `AsNoTracking()` for read-only queries
- Include navigation properties with `.Include()`
- Use async methods: `ToListAsync()`, `FirstOrDefaultAsync()`, `CountAsync()`
- Pagination: `Skip((page - 1) * pageSize).Take(pageSize)` pattern

### EF Core Models

- Partial classes: `public partial class Question`
- Virtual navigation properties for lazy loading: `public virtual Category Category { get; set; } = null!;`
- Null-forgiving operator: `= null!` on non-nullable reference properties
- Foreign key properties: `string CategoryId { get; set; } = null!;`

### Async/Await

- Use `async`/`await` for I/O operations (database, HTTP)
- Return `Task` or `Task<T>` for async methods
- Avoid `.Result` or `.Wait()` (use async all the way)

### Error Handling

- Throw `ArgumentException` for invalid parameters with descriptive German messages
- Validate input at class boundaries (constructors, public methods)
- Use `try-catch` where appropriate, especially for parsing
- Example: `throw new ArgumentException("Der Nenner darf nicht Null sein.");`

### Testing (xUnit)

- Test class name: `[ClassName]Tests` (e.g., `BruchTests`)
- Use `[Fact]` for single test cases
- Use `[Theory]` with `[InlineData(...)]` for parameterized tests
- Arrange-Act-Assert pattern
- Test both success and failure paths
- Test edge cases (empty, null, boundary values)
- Verify exception messages for `ArgumentException`:
  ```csharp
  var ex = Assert.Throws<ArgumentException>(() => new Bruch("1 1/0"));
  Assert.Equal("Der Nenner darf nicht Null sein.", ex.Message);
  ```

### Blazor Components

- Use Razor Components (`.razor`)
- Register services in `Program.cs` with `AddRazorComponents()`
- Use `@code` block for C# logic
- Use `[Parameter]` attribute for component parameters with default values

### Console Applications

- `Program.cs` with top-level statements or `internal static class Program`
- Namespace at file level
- Entry point in `Main` via top-level statements

## Git & Commits

- Jede Commit-Message MUSS die korrespondierende Ticket-Nummer (z.B. ` #2 `) enthalten.
- Die Ticket-Nummer muss von Leerzeichen umgeben sein (außer am Anfang oder Ende der Nachricht).

## Existing Cursor/Copilot Rules

- No `.cursor/rules/` or `.cursorrules` found
- No `.github/copilot-instructions.md` found
- `.editorconfig` in `2023_Webserver/` enforces brace style: no new line before open brace

## Language

- All user-facing text, comments, and documentation in German
- Technical terms in English (e.g., "Constructor", "Entity Framework", "ViewModel")
- Test method names can be English or German, but descriptive
- Exception messages in German

## Knowledge Bootstrap
Before starting any task, read the following files in order:
1. `docs/ai/HANDOFF.md` ← **read first, act on it**
2. `docs/ai/CONVENTIONS.md`
3. `docs/ai/DECISIONS.md`
4. `docs/ai/PITFALLS.md`
5. `docs/ai/STATE.md`
6. `docs/ai/DOMAIN.md` (if task involves business logic)

If `HANDOFF.md` contains open tasks, complete them before starting
any new work unless the user explicitly says otherwise.
