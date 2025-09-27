# scaffold

## gen project

```sh
dotnet new mvc --name MyApp -f net8.0 --force
```

## add sqlite and design

(ändert in .csproj)

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Set up the local tool:

```bash
dotnet new tool-manifest
dotnet tool install dotnet-ef
# dotnet tool run dotnet-ef now possible
```

## Create an initial migration:

> **Note:** Run the following commands from the project directory that contains your `DbContext` class.

```bash
dotnet ef migrations add InitialCreate  # erzeugt die erste migration im code
dotnet ef database update  # erhzeugt die _migrations table
```

## da hab ich mich verlaufen dann, ich wollte scaffolden!

```bash
dotnet ef dbcontext scaffold "Data Source=opentdb-app.sqlite" Microsoft.EntityFrameworkCore.Sqlite --output-dir Models --context-dir Models --context AppDbContext --force
```
