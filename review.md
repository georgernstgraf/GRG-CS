# Code Review - GRG-CS Projekt

Dieses Dokument enthält eine Übersicht und Bewertung der Code-Qualität basierend auf den aktuellen Implementierungen im Repository.

## Zusammenfassung

Das Projekt umfasst mehrere .NET 8.0 Anwendungen, darunter eine Bibliotheksimplementierung für Brüche (`Bruch`) und eine ASP.NET Core MVC Anwendung (`quiz`). Die Code-Basis folgt weitgehend modernen .NET-Konventionen, weist jedoch in spezifischen Bereichen (insbesondere bei der Validierung und Fehlerbehandlung) Verbesserungspotenzial auf.

---

## 1. Modul: 3ahwii/2025-11_Bruch (Bruch-Klasse)

### Positiv

- **Kapselung**: Felder sind als `private` markiert (`_ganz`, `_nenner`, `_zaehler`).
- **Mathematische Korrektheit**: Implementierung des Euklidischen Algorithmus (`Gcd`) zur Kürzung.
- **Benennung**: Folgt den deutschen Namenskonventionen für Bildungsprojekte (z.B. `Addiere`, `Kürze`).

### Kritische Anmerkungen / Verbesserungsvorschläge

- **Eingabevalidierung im Konstruktor**:
  - Der Konstruktor `Bruch(string bruchtext)` geht davon aus, dass der String immer ein Leerzeichen enthält (`Split(' ')`). Dies führt zu einer `IndexOutOfRangeException`, wenn nur "3" oder "7/8" übergeben wird, obwohl der Kommentar (Zeile 12) dies als Anforderung listet.
  - Es fehlen `try-catch`-Blöcke oder `int.TryParse`-Prüfungen für robustere Fehlerbehandlung.
- **Division durch Null**:
  - Es gibt keine Prüfung, ob der `nenner` Null ist. Dies sollte im Konstruktor validiert werden (z.B. `ArgumentException`).
- **Unveränderlichkeit (Immutability)**:
  - Obwohl `Addiere` ein neues Objekt zurückgibt, sind die internen Felder nicht `readonly`. In mathematischen Klassen ist Immutability oft bevorzugt.

---

## 2. Modul: 2025_Backend_SQLite_Partials (ASP.NET Core MVC)

### Positiv

- **Moderner Stack**: Verwendung von .NET 8, EF Core mit `AsNoTracking()` für Lesezugriffe und async/await.
- **Design Patterns**: Einsatz von ViewModels (`QuestionIndexViewModel`) und Dependency Injection im `QuestionController`.
- **Naming**: Konsequente Verwendung von File-scoped Namespaces und PascalCase für Properties.

### Kritische Anmerkungen / Verbesserungsvorschläge

- **Modell-Struktur**:
  - Die Property `Question1` in der Klasse `Question` deutet auf ein automatisches Scaffolding hin, das nicht manuell bereinigt wurde. Ein aussagekräftigerer Name wie `Text` oder `Content` wäre besser.
  - Die Navigation-Properties sind `virtual`, was Lazy Loading ermöglicht, aber in Web-APIs/Controllern vorsichtig eingesetzt werden muss (hier wird korrekt mit `.Include()` gearbeitet).
- **Fehlerbehandlung**:
  - Im `Index`-Action des `QuestionController` wird bei leeren Ergebnissen nur geloggt. Eine benutzerfreundliche Meldung in der View sollte sichergestellt sein.

---

## 3. Allgemeine Standards (AGENTS.md Compliance)

| Kriterium | Status | Anmerkung |
| :--- | :---: | :--- |
| **Target Framework** | ✅ | .NET 8.0 wird konsistent genutzt. |
| **Sprache** | ✅ | Kommentare und Logik-Namen sind auf Deutsch (wie gefordert). |
| **Unit Tests** | ✅ | `BruchTest` Projekt vorhanden; nutzt xUnit. |
| **Klammer-Stil** | ✅ | Entspricht der `.editorconfig` (keine neue Zeile vor öffnender Klammer). |
| **Nullable Reference Types** | ✅ | In Models aktiv (`null!`). |

---

## Empfohlene nächste Schritte

1. **Robusterer Parser für `Bruch`**: Implementierung einer Logik, die verschiedene Formate ("3", "1/2", "1 1/2") sicher erkennt.
2. **Validierung**: Hinzufügen von `ArgumentException` bei ungültigen mathematischen Zuständen (Nenner = 0).
3. **Refactoring Models**: Umbenennung von unklaren Scaffolding-Namen (`Question1`).
