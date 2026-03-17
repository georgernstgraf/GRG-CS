# Hausübungen 3AHWII SWP OOP (C#)

> PLF am 27. Mai

---

## Hausübung vom 11. März 2026

### Thema: Interfaces (Kapitel 13)

**Aufgabenstellung:**
Entwickle ein kleines Konsolenprogramm für ein Inventarsystem. Es gibt verschiedene Gegenstände, die alle einen Namen haben und Informationen ausgeben können.

1. Erstelle ein Interface `IInventarGegenstand` mit folgenden Elementen:
   - Property `string Name { get; }`
   - Methode `string BeschreibeDich();`

2. Erstelle zwei Klassen:
   - `Waffe`: Hat zusätzlich ein `int Schaden`.
   - `Heiltrank`: Hat zusätzlich ein `int Heilwert`.

3. Implementiere das Interface in beiden Klassen. Die Methode `BeschreibeDich()` soll einen aussagekräftigen String zurückgeben (z.B.: *"Ich bin das Schwert und mache 15 Schaden."*).

4. **Main-Methode:**
   - Erstelle eine `List<IInventarGegenstand>`.
   - Füge eine `Waffe` und einen `Heiltrank` hinzu.
   - Iteriere mit einer `foreach`-Schleife durch die Liste und rufe für jeden Gegenstand `BeschreibeDich()` auf.

**Lernziel:**
Verstehen, dass man Objekte unterschiedlicher Klassen in einer gemeinsamen Liste speichern kann, solange sie das gleiche Interface implementieren.

---

## Hausübung vom 7. Jänner 2026

### Thema: CSV-Dateien mit CsvHelper

**Aufgabenstellung:**
Lies die Datei `persons.csv` mit der Bibliothek CsvHelper ein und gib den Inhalt in der Konsole aus.

- **Für sehr gut:** Speichere die Daten in einem Array.

**Hinweis:** Siehe dazu die Folien zur CSV-Thematik.

---

## Hausübung vom 26. November 2025

### Thema: Bruch-Klasse dokumentieren

**Aufgabenstellung:**
Die Hausübung befindet sich im Kommentar der Bruch-Klasse (`Bruch.cs`).

**Hinweis:** Schau in den Quellcode der Klasse für die genaue Aufgabenstellung.

---

## Hausübung vom 12. November 2025

### Thema: Debugger-Konfiguration und Tests

**Aufgabenstellung:**

1. **Debugger-Konfiguration:** Erstelle eine Debugger-Konfiguration in Rider und weise sie nachweislich mit einem Screenshot nach.

2. **Kommandozeilenargumente:** Commandline args verarbeiten, bei Fehlern eine Exception bzw. Hilfe anbieten.

3. **Brüche gekürzt ausgeben:** Mit Hilfe der `ToString()`-Methode.

4. **Testmethoden implementieren:**

   Was wird getestet?
   - Gültige Ergebnisse werden asserted, z.B. `"1 1/2"`, `"2 1/2"`, `4`
   - Mehrere Testfälle sind ideal
   - Es soll auch geprüft werden, ob eine Exception kommt bei ungültigem Wert für den Konstruktor
   - Idealerweise ein paar richtige und ein paar unrichtige Argumente

---

## Hausübung vom 5. November 2025

### Thema: Brüche-Klasse Neuauflage

**Wiederholung:** `class`, `instance`, `constructor`, `attributes`, `args[]`, `int.Parse`, `dotnet`-Befehle

**Aufgabenstellung:**

- `ToString()` soll immer Ganzzahl und den Bruch gekürzt liefern, z.B. `"3 7/11"`, aber auch `"3/4"` (ohne führende Null)
- Alle Exceptions sollen gefangen und dem User eine sinnvolle Rückmeldung gegeben werden

---

## Hausübung vom 17. September 2025

### Thema: xUnit und Random-Tests

**Aufgabenstellung:**

- Informiere dich über xUnit
- Generiere Testfälle mit `Random()`

---

## Hausübung vom 10. September 2025

### Thema: Tests, throw/catch, xUnit

**Aufgabenstellung:**

- Programm inkl. Tests fertigstellen!
- `throw` / `try` / `catch` verwenden
- xUnit verwenden

**Themen:**
- OO Design
- Operator Overload
- Strings parsen
- Neue Webapp

---

## Hausübung vom 3. September 2025

### Thema: Brüche addieren

**Aufgabenstellung:**

1. GitHub-Repo erstellen (falls nötig) und URL an grafg@ schicken.

2. Schreibe ein Konsolenprogramm, welches 2 Brüche addiert.

   **Beispiel:**
   ```
   dotnet run "2 3/8" "1 5/6"
   ```
   
   **Erwartete Ausgabe:**
   ```
   4 5/24
   ```
