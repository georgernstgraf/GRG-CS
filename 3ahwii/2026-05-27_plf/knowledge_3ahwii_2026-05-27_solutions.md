# PLF – 3AHWII – Lösungen

**Datum:** 27.05.2026  
**Themen:** Agentic Coding mit KI, C#-Interfaces, Grundlagen Entity Framework Core

---

## Teil 1: Multiple-Choice – Lösungen

### Agentic Coding mit KI (5 Fragen)

---

### Frage 1: Definition Agentic Coding

- [x] A) **Richtig** – Agentic Coding bezeichnet den Einsatz von KI-gestützten Agenten, die Entwickler beim Schreiben, Debuggen, Refactoren und Dokumentieren von Code unterstützen.
- [ ] B) **Falsch** – Agentic Coding-Systeme arbeiten unterstützend, nicht vollständig autonom. Der Entwickler behält die Kontrolle und Überprüfung.
- [x] C) **Richtig** – Opencode läuft z. B. in der Kommandozeile (TUI), andere Tools sind in IDEs integriert.
- [ ] D) **Falsch** – Agentic Coding umfasst viel mehr als Chatbots: Code-Generierung, Debugging, Refactoring, Lernen, etc.

**Punkte:** A, C ankreuzen = 2 richtige + 2 korrekt nicht angekreuzt = 4/4

---

### Frage 2: Inference Provider

- [x] A) **Richtig** – Groq ist bekannt für extrem schnelle Inferenz und bietet einen kostenlosen Tier.
- [x] B) **Richtig** – Ollama läuft 100 % lokal und kostenlos, keine Internetverbindung nötig.
- [x] C) **Richtig** – OpenRouter aggregiert viele Modelle unter einer API.
- [ ] D) **Falsch** – Viele Provider (Groq, Ollama, Gemini, Cloudflare Workers AI) bieten kostenlose Tiers.

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 3: Open-Source vs. Closed-Source

- [x] A) **Richtig** – Open-Source-Modelle (Llama, Mistral, Qwen) können selbst gehostet, angepasst und feinabgestimmt werden.
- [x] B) **Richtig** – Closed-Source-Modelle (GPT-4, Claude, Gemini) sind nur über APIs nutzbar, Architektur und Gewichte sind nicht öffentlich.
- [ ] C) **Falsch** – Closed-Source-Modelle sind oft (aber nicht immer) leistungsfähiger; Open-Source bietet mehr Kontrolle, nicht automatisch bessere Performance.
- [ ] D) **Falsch** – Closed-Source-Modelle geben keine Garantie zur Datenhoheit; Daten verlassen das eigene System bei der API-Nutzung.

**Punkte:** A, B ankreuzen = 2 richtige + 2 korrekt nicht angekreuzt = 4/4

---

### Frage 4: Best Practices im Agentic Coding

- [x] A) **Richtig** – Präzise, schrittweise Prompts führen zu besseren Ergebnissen.
- [x] B) **Richtig** – Kontext (Fehlermeldungen, Dateien, Projektstruktur) hilft der KI, die Situation zu verstehen.
- [ ] C) **Falsch** – Ergebnisse müssen immer überprüft werden; blindes Übernehmen kann Fehler einschleusen.
- [x] D) **Richtig** – `dotnet build` und `dotnet test` sind wichtige Validierungsschritte.

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 5: Opencode-Skills

- [x] A) **Richtig** – Ein Skill ist eine domänenspezifische Anweisung, die dem Agenten spezielle Fähigkeiten gibt (z. B. für .NET, React, etc.).
- [ ] B) **Falsch** – Skills können von jedem erstellt werden; sie sind als Markdown-Dateien im Projekt oder im Konfigurationsordner abgelegt.
- [x] C) **Richtig** – Skills werden in Markdown geschrieben und enthalten Anweisungen, Kontext, Workflows und Beispiele.
- [x] D) **Richtig** – Der Skill wird geladen, indem man seinen Namen im Prompt (z. B. "Lade Skill XYZ") oder über das Skill-Tool angibt.

**Punkte:** A, C, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### C#-Interfaces (10 Fragen)

---

### Frage 6: Interface-Grundlagen

- [ ] A) **Falsch** – Interfaces können keine Instanzfelder enthalten (nur Properties, Methoden, Events).
- [x] B) **Richtig** – Vor C# 8 enthielten Interfaces nur Signaturen, keine Implementierungen.
- [x] C) **Richtig** – Deklaration mit dem Schlüsselwort `interface`.
- [ ] D) **Falsch** – Eine Klasse kann beliebig viele Interfaces implementieren.

**Punkte:** B, C ankreuzen = 2 richtige + 2 korrekt nicht angekreuzt = 4/4

---

### Frage 7: Interface vs. abstrakte Klasse

- [x] A) **Richtig** – Abstrakte Klassen können implementierte Methoden enthalten; Interfaces (vor C# 8) nicht.
- [x] B) **Richtig** – C# unterstützt nur einfache Klassenvererbung, aber multiple Interface-Implementierung.
- [ ] C) **Falsch** – Weder Interfaces noch abstrakte Klassen haben Konstruktoren, die aufgerufen werden können (abstrakte Klassen haben Konstruktoren für abgeleitete Klassen, Interfaces nicht).
- [x] D) **Richtig** – Beide können nicht mit `new` instanziiert werden.

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 8: Mehrfach-Implementierung

- [x] A) **Richtig** – `IComparable` und `IDisposable` werden implementiert.
- [x] B) **Richtig** – Interfaces werden komma-getrennt nach dem Doppelpunkt aufgelistet.
- [x] C) **Richtig** – Die Klasse muss alle Member aller genannten Interfaces implementieren.
- [ ] D) **Falsch** – Die Reihenfolge spielt für die Funktionalität keine Rolle.

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 9: Polymorphie mit Interfaces

- [x] A) **Richtig** – Polymorphie: Die Liste vom Interface-Typ kann beliebige Implementierungen aufnehmen.
- [ ] B) **Falsch** – Interface-Methoden können direkt aufgerufen werden; ein Cast ist nur nötig für typspezifische Member.
- [x] C) **Richtig** – `foreach` ruft die Interface-Methode auf jedem Objekt auf (späte Bindung / Polymorphie).
- [x] D) **Richtig** – Polymorphie bedeutet: Gleicher Aufruf, unterschiedliches Verhalten je nach konkreter Implementierung.

**Punkte:** A, C, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 10: Interface-Member

- [x] A) **Richtig** – Methoden sind erlaubt.
- [x] B) **Richtig** – Properties sind erlaubt.
- [x] C) **Richtig** – Events sind erlaubt.
- [ ] D) **Falsch** – Private Felder mit Initialisierung sind nicht erlaubt (nur Properties, keine Felder).

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 11: Interface instanziieren

- [ ] A) **Falsch** – Interfaces können niemals mit `new` instanziiert werden.
- [x] B) **Richtig** – Interfaces sind Referenztypen, aber nicht instanziierbar.
- [x] C) **Richtig** – Dies ist der korrekte Weg: Variable vom Interface-Typ, Objekt vom Klassen-Typ.
- [ ] D) **Falsch** – Interfaces haben keine Konstruktoren.

**Punkte:** B, C ankreuzen = 2 richtige + 2 korrekt nicht angekreuzt = 4/4

---

### Frage 12: Implementierungszwang

- [x] A) **Richtig** – Fehlende Member führen zu einem Compiler-Fehler.
- [ ] B) **Falsch** – Wenn die Klasse `abstract` ist, können Interface-Member ausgelassen werden; eine nicht-abstrakte Klasse muss alle implementieren.
- [x] C) **Richtig** – `throw new NotImplementedException()` ist eine gültige (wenn auch provisorische) Implementierung.
- [x] D) **Richtig** – Die Signatur (Name, Parameter, Rückgabetyp) muss exakt übereinstimmen.

**Punkte:** A, C, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 13: Bekannte .NET-Interfaces

- [x] A) **Richtig** – `IComparable` ermöglicht Vergleich + Sortierung (z. B. `List<T>.Sort()`).
- [x] B) **Richtig** – `IDisposable` wird für `using`-Blöcke und Ressourcenfreigabe verwendet.
- [x] C) **Richtig** – `IEnumerable` ermöglicht `foreach`.
- [ ] D) **Falsch** – Die Interfaces sind unabhängig und können einzeln implementiert werden.

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 14: Explizite Interface-Implementierung

- [x] A) **Richtig** – Syntax: `returnType ISchnittstelle.Methode() { ... }`.
- [x] B) **Richtig** – Explizite Implementierungen sind ohne Cast auf das Interface nicht sichtbar.
- [x] C) **Richtig** – Bei Namenskonflikten (gleiche Signatur in zwei Interfaces) wird explizite Implementierung zur Auflösung verwendet.
- [ ] D) **Falsch** – Explizite Implementierungen sind implizit `private` und benötigen kein `public`.

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 15: Default-Implementierungen

- [x] A) **Richtig** – Default-Implementierungen können von der Klasse überschrieben werden.
- [ ] B) **Falsch** – Abstrakte Klassen bleiben relevant (Felder, Konstruktoren, Zugriffsmodifizierer).
- [ ] C) **Falsch** – Die Klasse kann die Default-Implementierung verwenden, ohne sie selbst zu schreiben.
- [x] D) **Richtig** – Default-Implementierungen erlauben das nachträgliche Erweitern von Interfaces ohne Breaking Changes.

**Punkte:** A, D ankreuzen = 2 richtige + 2 korrekt nicht angekreuzt = 4/4

---

### Entity Framework Core (10 Fragen)

---

### Frage 16: Was ist EF Core?

- [x] A) **Richtig** – EF Core ist ein ORM (Object-Relational Mapper).
- [ ] B) **Falsch** – EF Core unterstützt viele Datenbankanbieter (SQLite, SQL Server, PostgreSQL, etc.) über Provider-Pakete.
- [x] C) **Richtig** – Tabellen werden als C#-Klassen (Entitäten) modelliert.
- [ ] D) **Falsch** – EF Core reduziert den Bedarf an SQL, ersetzt es aber nicht vollständig.

**Punkte:** A, C ankreuzen = 2 richtige + 2 korrekt nicht angekreuzt = 4/4

---

### Frage 17: DbContext

- [x] A) **Richtig** – Der DbContext ist die zentrale Klasse für die Kommunikation mit der Datenbank.
- [x] B) **Richtig** – DbContext ist für kurze Lebensdauer ausgelegt (pro Unit-of-Work ein neuer Context).
- [ ] C) **Falsch** – DbContext ist abstrakt; man erbt davon und erstellt eine eigene Context-Klasse.
- [x] D) **Richtig** – Der Change-Tracker verfolgt Änderungen; `SaveChangesAsync()` persistiert sie.

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 18: DbSet<T>

- [x] A) **Richtig** – `DbSet<T>` repräsentiert eine Tabelle für Entitäten vom Typ `T`.
- [x] B) **Richtig** – Der Change-Tracker verwaltet alle geladenen Entitäten.
- [x] C) **Richtig** – Properties vom Typ `DbSet<T>` im DbContext definieren die Tabellen.
- [ ] D) **Falsch** – `DbSet<T>` unterstützt sowohl Lese- als auch Schreiboperationen.

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 19: UseSqlite

- [x] A) **Richtig** – `UseSqlite()` wird in der überschriebenen `OnConfiguring`-Methode aufgerufen.
- [x] B) **Richtig** – Der Verbindungsstring für SQLite verwendet `Data Source=...`.
- [ ] C) **Falsch** – Die Datenbank-Datei wird bei Bedarf automatisch erstellt; `UseSqlite` installiert kein Systempaket.
- [x] D) **Richtig** – Ohne diesen Aufruf weiß EF Core nicht, welche Datenbank verwendet werden soll.

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 20: Code-First vs. Database-First

- [x] A) **Richtig** – Code-First: C#-Klassen definieren das Modell, Migrationen generieren die DB.
- [x] B) **Richtig** – Database-First: Bestehende DB wird in C#-Klassen übersetzt (Scaffolding).
- [ ] C) **Falsch** – Beide Ansätze können im selben Projekt kombiniert werden.
- [x] D) **Richtig** – Der Entwickler definiert alle Entitäten, Beziehungen und Constraints in C#.

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 21: Migrationen

- [x] A) **Richtig** – Migrationen erzeugen ein inkrementelles Update des DB-Schemas.
- [x] B) **Richtig** – `Add-Migration` erstellt eine C#-Migrationsklasse im Projekt.
- [x] C) **Richtig** – `Update-Database` führt ausstehende Migrationen aus.
- [ ] D) **Falsch** – Migrationen werden automatisch generiert (Code-First) oder können manuell ergänzt werden.

**Punkte:** A, B, C ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 22: CRUD-Operationen

- [x] A) **Richtig** – `Add()` markiert eine Entität als "neu eingefügt".
- [x] B) **Richtig** – `Remove()` markiert eine Entität als "zu löschen".
- [x] C) **Richtig** – `SaveChangesAsync()` ist die asynchrone Methode zum Persistieren.
- [x] D) **Richtig** – Der Change-Tracker erkennt Änderungen automatisch (`AutoDetectChanges`).

**Punkte:** Alle vier korrekt = 4/4

---

### Frage 23: Sync vs. Async in EF Core

- [x] A) **Richtig** – Async-Methoden blockieren den Thread nicht und geben ihn an den Thread-Pool zurück.
- [x] B) **Richtig** – I/O-Operationen (Datenbank, Dateisystem, Netzwerk) profitieren besonders von Async.
- [ ] C) **Falsch** – Async-Methoden unterscheiden sich fundamental im Verhalten (Threading, await-Pattern).
- [x] D) **Richtig** – Ohne `await` wird der Task zwar gestartet, aber synchron abgewartet (kein Vorteil).

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 24: Navigation Properties

- [x] A) **Richtig** – Navigation Properties modellieren Beziehungen (z. B. Fremdschlüsselbeziehungen).
- [x] B) **Richtig** – `ICollection<Produkt>` auf der Kategorie-Seite bildet die 1:n-Beziehung ab.
- [ ] C) **Falsch** – `= null!` ist nur eine Option zur Compiler-Warnungs-Unterdrückung, kein Zwang.
- [x] D) **Richtig** – EF Core erkennt die Konvention: Fremdschlüssel `KategorieId` → Navigation `Kategorie`.

**Punkte:** A, B, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 25: Nullable Reference Types

- [x] A) **Richtig** – `null!` teilt dem Compiler mit: "Ich weiß, dass das gerade null ist, aber es wird später gesetzt."
- [ ] B) **Falsch** – Genau das Gegenteil: Die Property soll nicht null sein, kann aber erst nach der Instanziierung gesetzt werden.
- [x] C) **Richtig** – `<Nullable>enable</Nullable>` aktiviert die Nullable-Prüfung auf Projekt-Ebene.
- [x] D) **Richtig** – Ohne `= null!` (oder Initialisierung im Konstruktor) warnt der Compiler vor nicht initialisierten Non-Nullable-Properties.

**Punkte:** A, C, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

## Teil 2: Coding-Aufgaben – Lösungen

### Coding-Aufgabe 1: Interface definieren und polymorphe Liste

**Teil (a) – Interface definieren (4 Punkte)**

```csharp
public interface IFahrzeug
{
    string Typ { get; }
    string StarteMotor();
}
```

Bewertung:
- 1 Punkt für `public interface IFahrzeug`
- 1 Punkt für `string Typ { get; }`
- 1 Punkt für `string StarteMotor()`
- 1 Punkt für korrekte Syntax (kein Semikolon nach Interface-Name, keine Klammern bei Property)

**Teil (b) – Klassen implementieren (6 Punkte)**

```csharp
class Auto : IFahrzeug
{
    public string Typ => "Auto";
    public string StarteMotor() => "Der Automotor läuft.";
}

class Fahrrad : IFahrzeug
{
    public string Typ => "Fahrrad";
    public string StarteMotor() => "Fahrräder haben keinen Motor.";
}
```

Bewertung:
- 1 Punkt pro korrekter Interface-Implementierung (`: IFahrzeug`)
- 1 Punkt pro korrekter Property
- 1 Punkt pro korrekter Methode
- 1 Punkt für sinnvollen Rückgabewert bei `Fahrrad.StarteMotor()`

**Teil (c) – Polymorphe Liste (5 Punkte)**

```csharp
public static void Main()
{
    List<IFahrzeug> fahrzeuge = new();
    fahrzeuge.Add(new Auto());
    fahrzeuge.Add(new Fahrrad());

    foreach (var f in fahrzeuge)
    {
        Console.WriteLine($"{f.Typ}: {f.StarteMotor()}");
    }
}
```

Bewertung:
- 1 Punkt für `List<IFahrzeug>`
- 1 Punkt für `Add(new Auto())` und `Add(new Fahrrad())`
- 1 Punkt für `foreach (var f in fahrzeuge)`
- 1 Punkt für Property- und Methodenaufruf über das Interface (`f.Typ`, `f.StarteMotor()`)
- 1 Punkt für korrekte String-Interpolation

---

### Coding-Aufgabe 2: IComparable implementieren und sortieren

**Teil (a) – Klasse mit IComparable (8 Punkte)**

```csharp
class Mitarbeiter : IComparable<Mitarbeiter>
{
    public string Name { get; set; }
    public decimal Gehalt { get; set; }

    public Mitarbeiter(string name, decimal gehalt)
    {
        Name = name;
        Gehalt = gehalt;
    }

    public int CompareTo(Mitarbeiter? anderer)
    {
        return Gehalt.CompareTo(anderer.Gehalt);
    }
}
```

Bewertung:
- 1 Punkt für `IComparable<Mitarbeiter>`
- 1 Punkt für korrekte Zuweisung im Konstruktor
- 2 Punkte für korrekte `CompareTo`-Signatur
- 3 Punkte für korrekte Implementierung (`Gehalt.CompareTo(anderer.Gehalt)`)
- 1 Punkt für Null-Check oder Verwendung von `?`

**Alternative (absteigend sortieren):**
```csharp
public int CompareTo(Mitarbeiter? anderer)
{
    return anderer.Gehalt.CompareTo(Gehalt); // absteigend
}
```

Beide Varianten sind gültig, wenn die Tendenz passt. Aufgabe verlangt aufsteigend (erste Variante).

**Teil (b) – Liste sortieren und ausgeben (7 Punkte)**

```csharp
class Program
{
    static void Main()
    {
        var mitarbeiter = new List<Mitarbeiter>
        {
            new Mitarbeiter("Alice", 3500m),
            new Mitarbeiter("Bob", 4200m),
            new Mitarbeiter("Charlie", 2800m)
        };

        mitarbeiter.Sort();

        foreach (var m in mitarbeiter)
        {
            Console.WriteLine($"{m.Name}: {m.Gehalt}€");
        }
    }
}
```

Bewertung:
- 2 Punkte für `mitarbeiter.Sort()`
- 1 Punkt für `foreach`
- 2 Punkte für korrekte Ausgabe von Name und Gehalt
- 2 Punkte für korrekte Syntax und Format

**Erwartete Ausgabe:**
```
Charlie: 2800€
Alice: 3500€
Bob: 4200€
```

---

### Coding-Aufgabe 3: DbContext und Entitäten modellieren

**Teil (a) – Entität Kategorie (4 Punkte)**

```csharp
public class Kategorie
{
    public int KategorieId { get; set; }
    public string Name { get; set; } = "";

    public ICollection<Produkt>? Produkte { get; set; }
}
```

Bewertung:
- 1 Punkt für `ICollection<Produkt>` (auch `List<Produkt>` oder `ICollection` akzeptabel)
- 1 Punkt für korrekte Property-Bezeichnung (z. B. `Produkte`)
- 1 Punkt für nullable (`?`) oder Initialisierung
- 1 Punkt für korrekte Syntax

**Teil (b) – Entität Produkt (6 Punkte)**

```csharp
public class Produkt
{
    public int ProduktId { get; set; }
    public string Bezeichnung { get; set; } = "";
    public decimal Preis { get; set; }

    public int KategorieId { get; set; }

    public virtual Kategorie Kategorie { get; set; } = null!;
}
```

Bewertung:
- 1 Punkt für `string Bezeichnung` (oder `Name`, `Titel`)
- 1 Punkt für `decimal Preis`
- 1 Punkt für `int KategorieId` (Fremdschlüssel)
- 1 Punkt für `virtual Kategorie Kategorie` (Navigation Property)
- 1 Punkt für `= null!;`
- 1 Punkt für korrekte Syntax

**Teil (c) – DbContext (5 Punkte)**

```csharp
public class MeinDbContext : DbContext
{
    public DbSet<Kategorie> Kategorien { get; set; } = null!;
    public DbSet<Produkt> Produkte { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=meineDatenbank.db");
    }
}
```

Bewertung:
- 1 Punkt für `class ... : DbContext`
- 1 Punkt für `DbSet<Kategorie> Kategorien`
- 1 Punkt für `DbSet<Produkt> Produkte`
- 1 Punkt für `OnConfiguring`
- 1 Punkt für `UseSqlite("Data Source=...")`

---

### Coding-Aufgabe 4: Async CRUD mit EF Core

**Teil (a) – Create (4 Punkte)**

```csharp
using Microsoft.EntityFrameworkCore;

public static async Task Main()
{
    using var db = new MeinDbContext();
    await db.Database.EnsureCreatedAsync();

    var kategorie = new Kategorie { Name = "Elektronik" };
    db.Kategorien.Add(kategorie);
    await db.SaveChangesAsync();

    var produkt = new Produkt
    {
        Bezeichnung = "Laptop",
        Preis = 999.99m,
        KategorieId = kategorie.KategorieId
    };
    db.Produkte.AddAsync(produkt);
    await db.SaveChangesAsync();
```

Bewertung:
- 1 Punkt für `Add(kategorie)`
- 1 Punkt für `await db.SaveChangesAsync()`
- 1 Punkt für `KategorieId = kategorie.KategorieId`
- 1 Punkt für `AddAsync(produkt)` (auch `Add` akzeptabel)

**Teil (b) – Read mit FindAsync (5 Punkte)**

```csharp
    var gelesen = await db.Kategorien.FindAsync(kategorie.KategorieId);

    if (gelesen != null)
    {
        Console.WriteLine($"Gelesen: {gelesen.Name}");
    }

    var gesuchtesProdukt = await db.Produkte.FindAsync(1);

    if (gesuchtesProdukt != null)
    {
        Console.WriteLine($"Produkt: {gesuchtesProdukt.Bezeichnung} ({gesuchtesProdukt.Preis}€)");
    }
```

Bewertung:
- 1 Punkt für `FindAsync(kategorie.KategorieId)`
- 1 Punkt für `gelesen.Name`
- 1 Punkt für `FindAsync(1)`
- 1 Punkt für `null` im Vergleich
- 1 Punkt für `gesuchtesProdukt.Preis`

**Teil (c) – Update und Delete (6 Punkte)**

```csharp
    // Update
    var update = await db.Produkte.FindAsync(1);
    if (update != null)
    {
        update.Preis = 1099.99m;
        await db.SaveChangesAsync();
        Console.WriteLine("Preis aktualisiert.");
    }

    // Delete
    var delete = await db.Produkte.FindAsync(2);
    if (delete != null)
    {
        db.Produkte.Remove(delete);
        await db.SaveChangesAsync();
        Console.WriteLine("Produkt gelöscht.");
    }
}
```

Bewertung:
- 1 Punkt für `update.Preis = 1099.99m` (Property-Änderung)
- 1 Punkt für `await db.SaveChangesAsync()` nach Update
- 1 Punkt für `FindAsync(2)` zum Suchen des zu löschenden Objekts
- 1 Punkt für `Remove(delete)`
- 1 Punkt für `await db.SaveChangesAsync()` nach Delete
- 1 Punkt für korrekte Syntax und Struktur

---

## Punkteübersicht

| Teil | Max. Punkte |
|------|-------------|
| MC-Fragen Agentic Coding (5 × 4) | 20 |
| MC-Fragen Interfaces (10 × 4) | 40 |
| MC-Fragen EF Core (10 × 4) | 40 |
| Coding-Aufgabe 1 (Interface) | 15 |
| Coding-Aufgabe 2 (IComparable) | 15 |
| Coding-Aufgabe 3 (DbContext) | 15 |
| Coding-Aufgabe 4 (CRUD) | 15 |
| **Gesamt** | **160** |

---

## Notenschlüssel (Beispiel)

| Punkte | Note |
|--------|------|
| 144–160 | Sehr gut (1) |
| 128–143 | Gut (2) |
| 112–127 | Befriedigend (3) |
| 96–111 | Genügend (4) |
| 0–95 | Nicht genügend (5) |
