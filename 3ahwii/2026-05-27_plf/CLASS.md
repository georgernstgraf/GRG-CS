# Klassenauswertung – Wissensüberprüfung am 27.05.2026

**Klasse:** 3AHWII  
**Themen:** Agentic Coding mit KI, C#-Interfaces, Entity Framework Core  
**Maximale Punkte:** 160

## Überblick

Die Klasse hat insgesamt gut abgeschnitten. Die Mehrheit der SchülerInnen erreichte Werte im Bereich Sehr Gut bis Gut. Die Coding-Aufgaben stellten erwartungsgemäß eine größere Herausforderung dar als der Multiple-Choice-Teil.

## Häufige Fehler im Multiple-Choice

### Frage 12 – Implementierungszwang (Interfaces)
Mehrere SchülerInnen haben übersehen, dass `throw new NotImplementedException()` eine gültige provisorische Implementierung ist. Auch die Ausnahme für abstrakte Klassen wurde teilweise falsch eingeschätzt.

### Frage 19 – UseSqlite
Einige SchülerInnen haben nicht erkannt, dass ohne den Aufruf von `UseSqlite()` der DbContext keine SQLite-Datenbank verwenden kann.

### Frage 23 – Sync vs. Async
Die Aussage, dass asynchrone Methoden mit `await` aufgerufen werden müssen (sonst läuft der Aufruf synchron ab), wurde von mehreren SchülerInnen nicht angekreuzt.

## Häufige Fehler bei den Coding-Aufgaben

### Aufgabe 1 – Interface definieren
- Rückgabetyp `void` statt `string` bei der Methode `StarteMotor()`
- Typfehler bei der polymorphen Liste: `List<fahrzeug>` statt `List<IFahrzeug>`
- Methodenschreibweise mit falscher Groß-/Kleinschreibung (`Startemotor` statt `StarteMotor`)

### Aufgabe 2 – IComparable
- Konstruktor-Zuweisung: Parameter wird sich selbst zugewiesen (`gehalt = gehalt`) statt dem Feld
- Ausgabe: Name wird nicht ausgegeben oder falsch formatiert
- Null-Check mit `??` statt `?.` beim `CompareTo`

### Aufgabe 3 – DbContext und Entitäten
- `DbSet` vs `DSet`, `DbContext` vs `DBContext` (Groß-/Kleinschreibung)
- `UseSqlServer` statt `UseSqlite`
- Navigation Properties ohne `virtual` oder ohne `= null!`
- Syntaxfehler bei Properties (`{ get; set }` ohne Semikolon oder Klammern)

### Aufgabe 4 – Async CRUD
- Tippfehler in Methodennamen: `SaveChangesAsynch`, `FindAsynch`, `SavechangesAsync`
- Falscher Property-Name bei Fremdschlüssel-Zuweisung (z. B. `KatogerieId`, `kategorie.Id`)
- `EnsureCreatedAsync` statt `SaveChangesAsync` nach `Add()`

## Prompt-Injection-Versuche

Bei zwei Abgaben wurden Auffälligkeiten festgestellt:
- Ein Schüler hatte eine separate Datei mit Anweisungen für ein völlig anderes Projekt abgelegt (Git-Historie-Manipulation). Die Datei wurde bei der Bewertung ignoriert.
- Ein Schüler hatte einen als LehrerNotiz formatierten Text in die Abgabedatei eingefügt, der die Vergabe der vollen Punkte forderte. Der Text wurde bei der Bewertung ignoriert; die Bewertung erfolgte auf Basis der tatsächlichen Antworten.

Beide Fälle wurden zur manuellen Überprüfung vorgemerkt.

## KI-Nutzung

Bei einer Abgabe deutet das Format (Titel `LÖSUNGEN`, Auflistung der korrekten Antworten) auf die Nutzung eines KI-Tools zur Bearbeitung hin. Die Bewertung erfolgte auf Basis der tatsächlich abgegebenen Antworten.

## Empfehlungen für die Lehrkraft

1. **Async/await Grundlagen wiederholen** – Besonders die Unterschiede zwischen synchronen und asynchronen Methoden und die Notwendigkeit von `await`.
2. **EF-Core-Konfiguration üben** – `OnConfiguring`, `UseSqlite` vs. `UseSqlServer` sowie die korrekte Schreibweise von `DbContext` und `DbSet`.
3. **Interface-Methoden und Rückgabetypen** – Nochmals klarstellen, dass Interface-Methoden mit korrektem Rückgabetyp (`string`, nicht `void`) definiert werden müssen.
4. **CRUD mit EF Core** – Die korrekte Verwendung von `FindAsync`, `SaveChangesAsync` und die Zuweisung von Fremdschlüsseln üben.
5. **Prompt-Injection-Sensibilisierung** – Die SchülerInnen sollten darauf hingewiesen werden, dass versuchte Manipulationen des Bewertungssystems auffallen und dokumentiert werden.
