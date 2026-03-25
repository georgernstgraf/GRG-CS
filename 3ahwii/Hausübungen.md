# Hausübungen 3AHWII SWP OOP (C#)

> PLF am 27. Mai

---

## Hausübung vom 25. März 2026

### Übung: "Lagerverwaltung" (Dauer: ca. 60 Minuten)

**Ziel:** Implementierung einer Konsolenanwendung zur Verwaltung eines Ersatzteillagers.

#### Szenario

Du sollst ein System schreiben, um Ersatzteile in einem Lager zu verwalten. Du musst dabei die effizienteste Datenstruktur für den jeweiligen Zweck wählen.

#### Schritt 1: Array (Das feste Regal)

* Erstelle ein `string[]` namens `regalPlatze` mit einer festen Größe von 5.
* Initialisiere es mit 5 verschiedenen Ersatzteilnamen.
* Sortiere das Array alphabetisch.
* Gib alle Elemente des Arrays untereinander in der Konsole aus.

#### Schritt 2: List<T> (Die dynamische Einlagerung)

* Erstelle eine `List<string>` namens `eingangskorb` für Ersatzteile, die neu geliefert wurden.
* Füge 4 Teile dynamisch hinzu (z. B. "Schraube", "Mutter", "Bolzen", "Feder").
* Entferne das zweite Element aus der Liste.
* Überprüfe mit einer `if`-Abfrage, ob das Element "Schraube" noch in der Liste enthalten ist.
* Gib die Anzahl der verbleibenden Teile in der Liste aus.

#### Schritt 3: Dictionary (Das Such-System)

* Erstelle ein `Dictionary<int, string>`, das eine Artikelnummer (Key) mit einem Ersatzteilnamen (Value) verknüpft.
* Füge 3 Paare hinzu (z. B. 101: "Motor", 102: "Getriebe", 103: "Reifen").
* Schreibe eine Methode `FindArtikel(int id)`, die das Dictionary und eine ID entgegennimmt.
* Nutze `TryGetValue`, um sicher zu prüfen, ob die ID existiert:
  * Wenn ja: Gib den Namen des Teils aus.
  * Wenn nein: Gib eine Fehlermeldung aus, dass die ID unbekannt ist.
* **Zusatzaufgabe (optional):** Iteriere über das Dictionary und gib alle Einträge im Format `ID: [ID], Teil: [Name]` aus.

#### Schritt 4: Abschluss

* Überprüfe deinen Code auf saubere Formatierung.
* Stelle sicher, dass alle Namespaces korrekt eingebunden sind (`using System.Collections.Generic;`, `using System.Linq;`).

Der vollständige Code in einer einzigen Datei (`Program.cs`), der beim Ausführen alle Schritte nacheinander in der Konsole loggt.

---

## Hausübung vom 18. März 2026

### Thema: ref/out, Strings und Schleifen mit break/continue

**Aufgabenstellung:**

Erstelle eine Klasse `Einkaufsliste` mit folgenden Anforderungen:

1. **Felder und Properties:**
   * Ein Array für maximal 10 Artikel (Strings)
   * Ein Zähler für die aktuelle Anzahl der Artikel
   * Read-only Property `Anzahl` für den Zähler

2. **Methode mit `out`:**

   ```csharp
   public bool VersucheHinzufuegen(string artikel, out string meldung)
   ```

   * Fügt einen Artikel hinzu, wenn noch Platz ist
   * Gibt bei Erfolg `true` zurück und eine Bestätigungsmeldung
   * Gibt bei vollem Array `false` zurück und eine Fehlermeldung

3. **Methode mit `break`:**

   ```csharp
   public bool Enthaelt(string gesuchterArtikel)
   ```

   * Sucht nach einem Artikel im Array
   * Verwendet `break` um die Suche bei Fund abzubrechen

4. **Methode mit `continue`:**

   ```csharp
   public void GibKurzeNamenAus(int minLaenge)
   ```

   * Gibt alle Artikel aus, die kürzer als `minLaenge` Zeichen sind
   * Verwendet `continue` um längere Namen zu überspringen

5. **String-Vergleich (Bonus für sehr gut):**
   * Schreibe eine Methode, die zwei Strings sowohl mit `==` als auch mit `.Equals()` vergleicht
   * Teste mit: `string a = "Milch"; string b = "Mil" + "ch";`
   * Gib aus, ob beide Vergleiche das gleiche Ergebnis liefern

**Lernziele:**

* `out`-Parameter für Rückgabewerte verstehen
* `break` zum vorzeitigen Beenden von Schleifen einsetzen
* `continue` zum Überspringen von Iterationen verwenden
* Unterschied zwischen `==` und `.Equals()` bei Strings kennenlernen

---

## Hausübung vom 11. März 2026

### Thema: Interfaces (Kapitel 13)

**Aufgabenstellung:**
Entwickle ein kleines Konsolenprogramm für ein Inventarsystem. Es gibt verschiedene Gegenstände, die alle einen Namen haben und Informationen ausgeben können.

1. Erstelle ein Interface `IInventarGegenstand` mit folgenden Elementen:
   * Property `string Name { get; }`
   * Methode `string BeschreibeDich();`

2. Erstelle zwei Klassen:
   * `Waffe`: Hat zusätzlich ein `int Schaden`.
   * `Heiltrank`: Hat zusätzlich ein `int Heilwert`.

3. Implementiere das Interface in beiden Klassen. Die Methode `BeschreibeDich()` soll einen aussagekräftigen String zurückgeben (z.B.: *"Ich bin das Schwert und mache 15 Schaden."*).

4. **Main-Methode:**
   * Erstelle eine `List<IInventarGegenstand>`.
   * Füge eine `Waffe` und einen `Heiltrank` hinzu.
   * Iteriere mit einer `foreach`-Schleife durch die Liste und rufe für jeden Gegenstand `BeschreibeDich()` auf.

**Lernziel:**
Verstehen, dass man Objekte unterschiedlicher Klassen in einer gemeinsamen Liste speichern kann, solange sie das gleiche Interface implementieren.

---

## Hausübung vom 7. Jänner 2026

### Thema: CSV-Dateien mit CsvHelper

**Aufgabenstellung:**
Lies die Datei `persons.csv` mit der Bibliothek CsvHelper ein und gib den Inhalt in der Konsole aus.

* **Für sehr gut:** Speichere die Daten in einem Array.

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
   * Gültige Ergebnisse werden asserted, z.B. `"1 1/2"`, `"2 1/2"`, `4`
   * Mehrere Testfälle sind ideal
   * Es soll auch geprüft werden, ob eine Exception kommt bei ungültigem Wert für den Konstruktor
   * Idealerweise ein paar richtige und ein paar unrichtige Argumente

---

## Hausübung vom 5. November 2025

### Thema: Brüche-Klasse Neuauflage

**Wiederholung:** `class`, `instance`, `constructor`, `attributes`, `args[]`, `int.Parse`, `dotnet`-Befehle

**Aufgabenstellung:**

* `ToString()` soll immer Ganzzahl und den Bruch gekürzt liefern, z.B. `"3 7/11"`, aber auch `"3/4"` (ohne führende Null)
* Alle Exceptions sollen gefangen und dem User eine sinnvolle Rückmeldung gegeben werden

---

## Hausübung vom 17. September 2025

### Thema: xUnit und Random-Tests

**Aufgabenstellung:**

* Informiere dich über xUnit
* Generiere Testfälle mit `Random()`

---

## Hausübung vom 10. September 2025

### Thema: Tests, throw/catch, xUnit

**Aufgabenstellung:**

* Programm inkl. Tests fertigstellen!
* `throw` / `try` / `catch` verwenden
* xUnit verwenden

**Themen:**

* OO Design
* Operator Overload
* Strings parsen
* Neue Webapp

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
