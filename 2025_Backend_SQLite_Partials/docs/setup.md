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
