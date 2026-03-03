# Lösungen - Wissenstest 3AHWII - C# Programmierung

**Datum:** 03.03.2026

---

## Teil A: Multiple Choice - Lösungen

### Frage 1
**Richtige Antwort:** "Ganzzahl", "Zähler/Nenner" oder "Ganzzahl Zähler/Nenner"

**Erklärung:** Der verbesserte Konstruktor akzeptiert drei verschiedene Formate:
- Nur Ganzzahl: "3"
- Nur Bruch: "7/8"
- Gemischt: "2 3/4"

Siehe Commit 3296f5c: Der Code prüft mit `teileLeerzeichen.Length` ob es 1 oder 2 Teile gibt und behandelt diese entsprechend.

---

### Frage 2
**Richtige Antwort:** Es wird eine ArgumentException mit der Nachricht "Die Eingabe darf nicht leer sein." geworfen

**Erklärung:** Im Konstruktor wird zu Beginn geprüft:
```csharp
if (string.IsNullOrWhiteSpace(bruchtext))
{
    throw new ArgumentException("Die Eingabe darf nicht leer sein.");
}
```

---

### Frage 3
**Richtige Antwort:** `int.TryParse()`

**Erklärung:** `int.TryParse()` gibt einen boolschen Wert zurück (Erfolg/Misserfolg) und schreibt das Ergebnis in die out-Variable. Es wirft keine Exception bei ungültiger Eingabe, was für die Validierung ideal ist.

Beispiel aus dem Code:
```csharp
if (!int.TryParse(teileLeerzeichen[0], out _ganz))
{
    throw new ArgumentException("Der ganzzahlige Teil ist ungültig.");
}
```

---

### Frage 4
**Richtige Antwort:** ArgumentException mit der Nachricht "Der Nenner darf nicht Null sein."

**Erklärung:** Dies wird sowohl im öffentlichen Konstruktor (nach dem Parsen) als auch im privaten Konstruktor geprüft:

```csharp
if (_nenner == 0)
{
    throw new ArgumentException("Der Nenner darf nicht Null sein.");
}
```

Siehe Commit f5abd66: "add validation against division by zero in constructor"

---

### Frage 5
**Richtige Antwort:** Sie parst den Bruch-Teil (Zähler/Nenner) und validiert das Format

**Erklärung:** Die private Methode `ParseBruch()`:
- Teilt den String am '/'
- Prüft, ob genau 2 Teile vorhanden sind
- Versucht beide Teile mit `int.TryParse()` zu konvertieren
- Wirft eine `ArgumentException` bei ungültigem Format

```csharp
private void ParseBruch(string bruchString)
{
    var teileSchraegstrich = bruchString.Split('/');
    if (teileSchraegstrich.Length != 2 || 
        !int.TryParse(teileSchraegstrich[0], out _zaehler) || 
        !int.TryParse(teileSchraegstrich[1], out _nenner))
    {
        throw new ArgumentException("Der Bruch-Teil ist ungültig.");
    }
}
```

---

### Frage 6
**Richtige Antwort:** `[Theory]` und `[InlineData]`

**Erklärung:** `[Theory]` markiert einen parametrisierten Test, `[InlineData]` liefert die Parameter. Beispiel aus BruchTests.cs:

```csharp
[Theory]
[InlineData("3 7/11", "3 7/11")]
[InlineData("0 15/10", "1 1/2")]
[InlineData("3", "3")]
[InlineData("7/8", "0 7/8")]
public void ToString_Normalizes_And_Formats_For_Multiple_Inputs(string input, string expected)
{
    var b = new Bruch(input);
    Assert.Equal(expected, b.ToString());
}
```

---

### Frage 7
**Richtige Antwort:** Dass eine Exception geworfen wird und gibt die Exception zurück zur weiteren Prüfung

**Erklärung:** `Assert.Throws<T>()` verifiziert, dass eine Exception vom Typ T geworfen wird. Der Rückgabewert ist die geworfene Exception, sodass man deren Eigenschaften (z.B. Message) prüfen kann:

```csharp
var ex = Assert.Throws<ArgumentException>(() => new Bruch("1 1/0"));
Assert.Equal("Der Nenner darf nicht Null sein.", ex.Message);
```

---

### Frage 8
**Richtige Antwort:** Comma Separated Values

**Erklärung:** CSV = Comma Separated Values (kommaseparierte Werte), obwohl oft auch andere Trennzeichen (z.B. Semikolon) verwendet werden. Siehe Folien/WAS_IST_CSV.md.

---

### Frage 9
**Richtige Antwort:** CsvHelper

**Erklärung:** Laut README.md (2026-01-07) und Folien/WAS_IST_CSV.md wird das NuGet-Package "CsvHelper" für das Einlesen von CSV-Dateien empfohlen.

---

### Frage 10
**Richtige Antwort:** `int.TryParse()` wirft keine Exception bei ungültiger Eingabe, sondern gibt false zurück

**Erklärung:** 
- `int.Parse("abc")` wirft eine FormatException
- `int.TryParse("abc", out result)` gibt false zurück und result bleibt 0

Im Bruch-Konstruktor wurde `TryParse` bewusst gewählt, um Eingaben validieren zu können ohne try-catch-Blöcke.

---

### Frage 11
**Richtige Antwort:** Sie entfernt Leerzeichen am Anfang und Ende des Strings

**Erklärung:** `Trim()` entfernt Whitespace (Leerzeichen, Tabs, etc.) vom Anfang und Ende eines Strings. Im Bruch-Konstruktor wird es verwendet, um Eingaben wie " 2 3/4 " zu normalisieren: `bruchtext.Trim().Split(' ')`.

---

### Frage 12
**Richtige Antwort:** Sie verbessern die Code-Organisation und Vermeidung von Code-Duplikation

**Erklärung:** Private Hilfsmethoden wie `ParseBruch()`:
- Extrahieren wiederkehrende Logik (DRY-Prinzip: Don't Repeat Yourself)
- Verbessern die Lesbarkeit durch sprechende Methodennamen
- Ermöglichen einfacheres Testing (indirekt über öffentliche Methoden)
- Sind nur innerhalb der Klasse sichtbar (Encapsulation)

---

## Teil B: Freitext-Fragen - Musterlösungen

### Frage 13: Exception-Handling (5 Punkte)

**Musterlösung:**

Die Verwendung spezifischer `ArgumentException`s mit aussagekräftigen Nachrichten im Bruch-Konstruktor bietet mehrere Vorteile:

1. **Benutzerfreundlichkeit (1 Punkt):**
   - Aussagekräftige Fehlermeldungen wie "Der Nenner darf nicht Null sein." oder "Das Format ist ungültig. Erwartet: 'Ganzzahl Zähler/Nenner', 'Zähler/Nenner' oder 'Ganzzahl'." helfen dem Benutzer, das Problem zu verstehen und zu korrigieren.
   - Generische Meldungen wie "Fehler" wären weniger hilfreich.

2. **Testbarkeit (2 Punkte):**
   - Durch spezifische Exceptions können Tests gezielt prüfen, ob die richtige Exception bei der richtigen Bedingung geworfen wird.
   - Beispiel aus den Tests: `Assert.Equal("Der Nenner darf nicht Null sein.", ex.Message);` prüft die exakte Fehlermeldung.
   - Ohne diese Spezifität wäre nicht klar, welcher Validierungsfehler aufgetreten ist.

3. **Gezielte Fehlerbehandlung (2 Punkte):**
   - Aufrufende Code kann auf verschiedene Fehler unterschiedlich reagieren (z.B. unterschiedliche Fehlermeldungen anzeigen oder verschiedene Recovery-Strategien anwenden).
   - Die klare Trennung der Fehlerfälle (leere Eingabe, ungültiges Format, Division durch Null) ermöglicht präzise Fehlerbehandlung.

---

### Frage 14: Unit-Testing (5 Punkte)

**Musterlösung:**

**Unterschied (2 Punkte):**

1. **[Fact]-Test:**
   - Ein einzelner, parametrisierter Testfall
   - Führt die Testmethode genau einmal aus
   - Keine externen Parameter
   - Beispiel:
   ```csharp
   [Fact]
   public void Constructor_Parses_Mixed_Number()
   {
       var b = new Bruch("3 7/11");
       Assert.Equal("3 7/11", b.ToString());
   }
   ```

2. **[Theory]-Test:**
   - Parametrisierter Test mit mehreren Datensätzen
   - Führt die Testmethode für jedes `[InlineData]`-Attribut einmal aus
   - Alle Datensätze müssen bestehen, damit der Test besteht
   - Beispiel:
   ```csharp
   [Theory]
   [InlineData("3 7/11", "3 7/11")]
   [InlineData("0 15/10", "1 1/2")]
   [InlineData("3", "3")]
   [InlineData("7/8", "0 7/8")]
   public void ToString_Normalizes_And_Formats_For_Multiple_Inputs(string input, string expected)
   {
       var b = new Bruch(input);
       Assert.Equal(expected, b.ToString());
   }
   ```

**Wann welcher Typ sinnvoll ist (3 Punkte):**

- **[Fact]** ist sinnvoll für:
  - Einzigartige Testfälle, die sich nicht wiederholen
  - Tests mit komplexen Setup-Schritten
  - Tests, die genau einen spezifischen Szenario testen (z.B. Additionsoperation)

- **[Theory]** ist sinnvoll für:
  - Testen der gleichen Logik mit verschiedenen Eingabewerten (Data-Driven Testing)
  - Grenzfälle und Äquivalenzklassen testen
  - Reduzierung von Code-Duplikation bei ähnlichen Tests
  - Im Bruch-Beispiel: Gleiches Parsing-Verhalten für verschiedene Bruch-Formate testen

---

### Frage 15: Code-Refactoring (5 Punkte)

**Musterlösung:**

**Vorteile der Refactoring-Änderungen (3 Punkte):**

1. **Funktionalität (1 Punkt):**
   - Die neue Version unterstützt drei verschiedene Eingabeformate (Ganzzahl, Bruch, Gemischt) statt nur einem.
   - Umfassende Validierung: Leere Eingaben, ungültige Formate und Division durch Null werden erkannt.
   - Bessere Fehlerberichterstattung durch spezifische Exception-Nachrichten.

2. **Lesbarkeit und Wartbarkeit (1 Punkt):**
   - Die Extraktion von `ParseBruch()` als private Hilfsmethode reduziert Duplikation und macht den Code selbstdokumentierend.
   - Die Strukturierung mit if-else-if-Blöcken für verschiedene Eingabeformate macht die Logik klarer.
   - Jeder Validierungsschritt ist explizit und nachvollziehbar.

3. **Robustheit (1 Punkt):**
   - Verwendung von `TryParse` statt `Parse` verhindert Exceptions bei der Konvertierung.
   - Konsistente Validierung in beiden Konstruktoren (öffentlich und privat).

**Mögliche Nachteile/Kompromisse (2 Punkte):**

1. **Erhöhte Komplexität:**
   - Die ursprüngliche Version war mit 5 Zeilen einfacher zu verstehen.
   - Die neue Version hat ~50 Zeilen Code mit verschachtelten Bedingungen.
   - Für Anfänger kann die Logik mit mehreren if-else-Blöcken und TryParse-Aufrufen schwerer zu durchblicken sein.

2. **Kompromiss:**
   - Die erhöhte Komplexität ist gerechtfertigt durch die deutlich verbesserte Funktionalität und Robustheit.
   - Die Komplexität wird durch gute Strukturierung und Hilfsmethoden beherrschbar gehalten.
   - Die Tests (siehe Frage 14) dokumentieren das erwartete Verhalten und erleichtern das Verständnis.

**Fazit:** Das Refactoring war sinnvoll, da es die Qualität der Software deutlich verbessert hat, auch wenn der Code nun länger ist. Die Investition in Lesbarkeit (sprechende Methoden, klare Struktur) zahlt sich bei Wartung und Erweiterung aus.

---

## Bewertungshinweise

- **Multiple Choice:** Je 1 Punkt pro Frage (12 Punkte gesamt)
- **Freitext:** Je max. 5 Punkte pro Frage (15 Punkte gesamt)
- **Gesamtpunktzahl:** 27 Punkte
- **Notenschlüssel (Vorschlag):**
  - 24-27 Punkte: Sehr Gut (1)
  - 20-23 Punkte: Gut (2)
  - 16-19 Punkte: Befriedigend (3)
  - 12-15 Punkte: Genügend (4)
  - 0-11 Punkte: Nicht Genügend (5)
