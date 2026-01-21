# GRG-CS Agent Guidelines

This repository contains .NET 8.0 projects for educational purposes (German school projects). All code comments and documentation are in German.

## Build/Test Commands

### Solution Level

- `dotnet build` - Build entire solution
- `dotnet test` - Run all tests in solution
- `dotnet test --filter "FullyQualifiedName~MethodName"` - Run specific test by method name
- `dotnet test 3ahwii/2025-11_Bruch/BruchTest/BruchTest.csproj` - Run tests in specific project

### Single Project

- `dotnet build path/to/Project.csproj` - Build single project
- `dotnet run --project path/to/Project.csproj` - Run console/Web app

## Code Style Guidelines

### Framework & Tools

- Target Framework: .NET 8.0
- Testing: xUnit (with Microsoft.NET.Test.Sdk)
- EF Core: Entity Framework Core with SQLite provider
- Build: `dotnet build` / `dotnet test`

### Naming Conventions

- **Classes**: PascalCase (e.g., `Bruch`, `QuestionController`)
- **Methods**: PascalCase, descriptive German names (e.g., `Addiere`, `Kürze`)
- **Properties**: PascalCase (e.g., `CorrectAnswerId`, `Stecker`)
- **Private fields**: Underscore prefix (e.g., `_ganz`, `_nenner`, `_context`)
- **Parameters**: camelCase (e.g., `bruchtext`, `plaetze`)
- **Constants/Fields**: PascalCase for readonly properties (e.g., `Stecker`)

### Namespace & File Structure

- File-scoped namespaces: `namespace BruchName;` or `namespace quiz.Models;`
- One class per file (matching filename)
- Folder structure mirrors namespace structure
- Test projects: `ProjectNameTest` folder, `ProjectNameTests` class

### Language Features

- **ImplicitUsings**: Enabled (avoid redundant using statements)
- **Nullable Reference Types**: Enabled (`<Nullable>enable</Nullable>`)
- **Null-forgiving operator**: Use `null!` for non-nullable properties initialized by EF Core
- **Brace placement**: No newline before open brace (`csharp_new_line_before_open_brace = none`)
- **String interpolation**: Use `$"{variable}"` format
- **Type inference**: Use `var` for local variables when type is obvious

### Class Design

- **Accessibility**: Public for API classes, private for implementation helpers
- **Sealed**: Mark controllers as `sealed` when not intended for inheritance
- **Constructors**: Public with parameter validation using `ArgumentException`
- **Partial classes**: Use for EF Core models scaffolded from database
- **Properties**: Auto-implemented when possible, virtual for navigation properties

### Dependency Injection

- Constructor injection for services (e.g., `ILogger<T>`, `DbContext`)
- Register services in `Program.cs` with `builder.Services.Add...()`
- Use `readonly` for injected services

### ASP.NET Core Controllers

- Namespace: `namespace ProjectName.Controllers;`
- Inherit from `Controller` or `ControllerBase`
- Use `[HttpGet]`, `[HttpPost]` attributes for actions
- Return `IActionResult` or `async Task<IActionResult>`
- Log information with structured logging: `_logger.LogInformation("Message {Param}", value);`

### Entity Framework Core

- Use `AsNoTracking()` for read-only queries
- Include navigation properties with `.Include()`
- Use async methods: `ToListAsync()`, `FirstOrDefaultAsync()`, `CountAsync()`
- Pagination: `Skip().Take()` pattern

### Async/Await

- Use `async`/`await` for I/O operations (database, HTTP)
- Return `Task` or `Task<T>` for async methods
- Avoid `.Result` or `.Wait()` (use async all the way)

### Error Handling

- Throw `ArgumentException` for invalid parameters with descriptive German messages
- Use `try-catch` where appropriate, especially for parsing
- Validate input at class boundaries (constructors, public methods)

### Testing (xUnit)

- Test class name: `[ClassName]Tests` (e.g., `BruchTests`)
- Use `[Fact]` for single test cases
- Use `[Theory]` with `[InlineData(...)]` for parameterized tests
- Arrange-Act-Assert pattern
- Test both success and failure paths
- Test edge cases (empty, null, boundary values)

### EF Core Models

- Partial classes: `public partial class Question`
- Virtual navigation properties for lazy loading: `public virtual Category Category { get; set; } = null!;`
- Null-forgiving operator: `= null!` on non-nullable reference properties
- Foreign key properties: `string CategoryId { get; set; } = null!;`

### Blazor Components

- Use Razor Components (`.razor`)
- Register services in `Program.cs` with `AddRazorComponents()`
- Use `@code` block for C# logic

### Console Applications

- `Program.cs` with top-level statements
- Namespace at file level (implicit)
- Entry point in `Main` via top-level statements

## Existing Cursor/Copilot Rules

- No `.cursor/rules/` or `.cursorrules` found
- No `.github/copilot-instructions.md` found
- `.editorconfig` in `2023_Webserver/` enforces brace style: no new line before open brace

## Language

- All user-facing text, comments, and documentation in German
- Technical terms in English (e.g., "Constructor", "Entity Framework")
- Test method names can be English or German, but descriptive
