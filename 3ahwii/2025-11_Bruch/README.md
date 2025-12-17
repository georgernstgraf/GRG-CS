# Bruch und Testmethoden

## Dotnet Kommandos zum Anlegen der Verzeichnis-Struktur mit Tests

### Wir starten in einem frischen, leeren Verzeichnis und legen erstmal NUR das Solution File an:

- dotnet new sln -n Bruch

### Anlegen des Bruch Projektes:

- dotnet new console -o Bruch

### Hinzufügen des Projektes zum Solution File:

- dotnet sln add Bruch/Bruch.csproj

### Anlegen des Test Projektes:

- dotnet new xunit -o BruchTest

### Und wieder zur Solution dazutun:

- dotnet sln add BruchTest/BruchTest.csproj

### Zum Schluss eine Referenz in das Testprojekt geben

- dotnet add BruchTest/BruchTest.csproj reference Bruch/Bruch.csproj

## Ausführen der Tests:

- dotnet test
