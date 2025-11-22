# Wie man C# Sachen baut und startet

## dotnet build

- dotnet build -c release
- dotnet build -c debug
- dotnet publish -c release
- dotnet publish -c debug

Erzeugt Artefakte im Ordner bin/Debug/net8. Ausführung:

- dotnet ./bin/Debug/net8.0/2025-11_brueche.dll "1 4/5" "5 3/8"
- ./bin/Debug/net8.0/2025-11_brueche "1 4/5" "5 3/8"  # (viel schneller)

## dotnet publish

dotnet publish -p:PublishSingleFile=true