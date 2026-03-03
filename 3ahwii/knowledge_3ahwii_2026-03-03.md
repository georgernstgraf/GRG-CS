# Wissenstest 3AHWII - C# Programmierung

**Datum:** 03.03.2026  
**Dauer:** 20 Minuten  
**Hilfsmittel:** Keine (Closed Book)

---

## Teil A: Multiple Choice (7-12 Fragen)

**Anleitung:** Kreuzen Sie die richtige(n) Antwort(en) an. Es kann eine oder mehrere richtige Antworten geben.

---

### Frage 1
Welche Eingabeformate akzeptiert der verbesserte Bruch-Konstruktor?

- [ ] Nur "Ganzzahl Zähler/Nenner" (z.B. "2 3/4")
- [ ] Nur "Zähler/Nenner" (z.B. "7/8")
- [ ] "Ganzzahl", "Zähler/Nenner" oder "Ganzzahl Zähler/Nenner"
- [ ] Beliebige Zeichenketten ohne Prüfung

---

### Frage 2
Was passiert, wenn der Bruch-Konstruktor mit einem leeren String aufgerufen wird?

- [ ] Es wird eine NullReferenceException geworfen
- [ ] Es wird eine ArgumentException mit der Nachricht "Die Eingabe darf nicht leer sein." geworfen
- [ ] Der Bruch wird mit den Werten 0/1 initialisiert
- [ ] Das Programm stürzt mit einem StackOverflow ab

---

### Frage 3
Welche Methode wird im Bruch-Konstruktor verwendet, um sicher zu prüfen, ob ein String in eine Ganzzahl konvertiert werden kann?

- [ ] `int.Parse()`
- [ ] `Convert.ToInt32()`
- [ ] `int.TryParse()`
- [ ] `Regex.IsMatch()`

---

### Frage 4
Welche Exception wird geworfen, wenn der Nenner eines Bruchs 0 ist?

- [ ] DivideByZeroException
- [ ] ArgumentException mit der Nachricht "Der Nenner darf nicht Null sein."
- [ ] FormatException
- [ ] InvalidOperationException

---

### Frage 5
Was ist der Zweck der privaten Methode `ParseBruch()` in der Bruch-Klasse?

- [ ] Sie berechnet den größten gemeinsamen Teiler (GGT)
- [ ] Sie parst den Bruch-Teil (Zähler/Nenner) und validiert das Format
- [ ] Sie kürzt den Bruch
- [ ] Sie wandelt den Bruch in einen Dezimalwert um

---

### Frage 6
Welche xUnit-Attribute werden im Testprojekt verwendet, um mehrere Testfälle mit verschiedenen Eingaben zu definieren?

- [ ] `[Fact]` und `[InlineData]`
- [ ] `[Theory]` und `[InlineData]`
- [ ] `[Test]` und `[TestCase]`
- [ ] `[Parameterized]` und `[DataRow]`

---

### Frage 7
Was überprüft die Methode `Assert.Throws<ArgumentException>()` in einem xUnit-Test?

- [ ] Dass eine Exception geworfen wird und alle Tests danach übersprungen werden
- [ ] Dass eine Exception geworfen wird und gibt die Exception zurück zur weiteren Prüfung
- [ ] Dass keine Exception geworfen wird
- [ ] Dass der Test fehlschlägt, wenn eine Exception geworfen wird

---

### Frage 8
Was ist CSV?

- [ ] Character Separated Values
- [ ] Comma Separated Values
- [ ] C# Source Variable
- [ ] Common System Variable

---

### Frage 9
Welche NuGet-Package wird im Unterricht für das Einlesen von CSV-Dateien mit C# empfohlen?

- [ ] Newtonsoft.Json
- [ ] CsvHelper
- [ ] EntityFrameworkCore
- [ ] System.Data.SqlClient

---

### Frage 10
Was ist der Hauptunterschied zwischen `int.Parse()` und `int.TryParse()`?

- [ ] `int.Parse()` ist schneller als `int.TryParse()`
- [ ] `int.TryParse()` wirft keine Exception bei ungültiger Eingabe, sondern gibt false zurück
- [ ] `int.Parse()` kann Hexadezimalzahlen parsen, `int.TryParse()` nicht
- [ ] Es gibt keinen Unterschied

---

### Frage 11
Was bewirkt die Methode `string.Trim()` in C#?

- [ ] Sie entfernt alle Leerzeichen im String
- [ ] Sie entfernt Leerzeichen am Anfang und Ende des Strings
- [ ] Sie wandelt den String in Großbuchstaben um
- [ ] Sie teilt den String anhand eines Trennzeichens

---

### Frage 12
Welche Vorteile bietet die Verwendung von privaten Hilfsmethoden (wie `ParseBruch()`) in einer Klasse?

- [ ] Sie können nur von außerhalb der Klasse aufgerufen werden
- [ ] Sie verbessern die Code-Organisation und Vermeidung von Code-Duplikation
- [ ] Sie sind automatisch statisch
- [ ] Sie werden automatisch von xUnit getestet

---

## Teil B: Freitext-Fragen (2-3 Fragen)

**Anleitung:** Beantworten Sie die folgenden Fragen in ganzen Sätzen. Achten Sie auf Vollständigkeit und Präzision.

---

### Frage 13
**Exception-Handling (5 Punkte)**

Erklären Sie, warum es besser ist, im Bruch-Konstruktor spezifische `ArgumentException`s mit aussagekräftigen Nachrichten zu werfen, anstatt die Eingabe-Fehler einfach zu ignorieren oder generische Exceptions zu verwenden. Gehen Sie dabei auf:
- Die Bedeutung aussagekräftiger Fehlermeldungen für den Benutzer
- Die Testbarkeit des Codes
- Die Möglichkeit gezielter Fehlerbehandlung

---

### Frage 14
**Unit-Testing (5 Punkte)**

Beschreiben Sie den Unterschied zwischen einem `[Fact]`-Test und einem `[Theory]`-Test in xUnit. Geben Sie jeweils ein konkretes Beispiel aus der Bruch-Testklasse an und erklären Sie, wann welcher Testtyp sinnvoll ist.

---

### Frage 15
**Code-Refactoring (5 Punkte)**

Der Bruch-Konstruktor wurde von einer einfachen, direkten Implementierung zu einer komplexeren Version mit mehreren Validierungen und Hilfsmethoden refactored. Diskutieren Sie die Vorteile und möglichen Nachteile dieser Änderungen. Berücksichtigen Sie dabei:
- Lesbarkeit und Wartbarkeit des Codes
- Funktionalität (welche neuen Features wurden ermöglicht?)
- Komplexität (ist der Code nun schwerer zu verstehen?)

---

**Viel Erfolg!**
