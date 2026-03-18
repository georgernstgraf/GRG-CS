# 3AHWII SWP OOP (C#)

## PLF am 27. Mai

todo enum

## 2026-03-18_Kap_6

### Hausübung: ref/out, Strings und Schleifen mit break/continue

- cont bei 5.6 signaturen
- Referenz- und Wertetypen
- ref vs out
- kap 7 beziehungen v. Objekten
- kap 8 strings / .Equals / == / stringbuilder
- kap 9 schleifen + extra break / continue

## 2026-03-11

- fail fast vs. happy path, vorteile und aktuell standard: fail fast
- "ein Statement" (im context von if/else) vs "ein Block", der mit `{ ... }` eingeschlossen ist.
- $"BMI: {bmi:F2} - {bmiTyp}" ist ein sog. "template string", sehr nützlich und mächtig.
- Interfaces (Kap. 13) besprochen

### Hausübung: Schnittstellen für ein Inventarsystem

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

***

Das ist überschaubar, ohne viel "Boilerplate"-Code, und zeigt den Nutzen der Abstraktion direkt in der Praxis. Passt das für dein Niveau?

## 2026-03-04

- knowhow check (ben, moritz nicht werten)
- georgernstgraf/opencode-helpers repository für Agent zeugs
- ENUM
- skriptum 2.2. naming conventions
- 2.3.
- 2.4. fail fast vs. happy path
- 4.5. wichtige assertions
- kap 5 bis vor signaturen gemacht.

## 2026-02-24, 2026-02-17, 2026-02-10

Intensive Beschäftigung mit Opencode.ai und agentic coding

- commands
- skills
- inference providers (github, opencode zen, openrouter)
- opensource vs closed source models

## 2026-01-07

CSV, siehe in Folien
HÜ: persons.csv einlesen mit CsvHelper, Ausgabe in Konsole

- für sehr gut: Speichern in ein Array.

## 2025-11-26

Installation Rider

HÜ: im Kommentar der Bruch Klasse

C-Sharp Repo: dieses hier ;)

(und es geht auch dort weiter)

## 2025-11-12

HÜ: Debugger Config nachweislich (Screenshot) erstellen.

- Commandline args verarbeiten, exception bzw. Hilfe anbieten
- Brüche gekürzt ausgeben mit Hilfe der toString methode
- Testmethoden implementieren

Was wird getestet?

- gültige Ergebnisse werden asserted z.B. "1 1/2", "2 1/2", 4
- davon mehrere sind ideal
- es soll auch geprüft werden, ob exception kommt bei ungültigem Wert für den Construktor
- idealerweise ein paar richtige und ein paar unrichtige args

## 2025-11-05

- wh: class / instance / constructor / attributes
- wh: args[], int.Parse, ...
- dotnet ..

HÜ: Neuauflage Brüche

- toString() soll bitte immer ganzzahl und den Bruch gekürzt liefern, wie zB "3 7/11", aber auch "3/4"
- alle exceptions bitte fangen und dem User sinnvolle Rückmeldung geben.

## Notes für GRG

- OO ist noch einiger Bedarf

## 2025-09-17

HÜ

- zu xunit informieren
- testfälle generieren mit random()

## 2025-09-10

HÜ: Programm incl. Tests fertigstellen!!
throw / try / catch
xunit verwenden

- oo design
- operator overload
- strings parsen
- new webapp

## HÜ vom 3.9

GH Repo erstellen wenn nötig, URL an grafg@ schicken.

Console Programm, welches 2 Brüche addiert.

zB. `dotnet run "2 3/8" "1 5/6"` => `4 5/24`
