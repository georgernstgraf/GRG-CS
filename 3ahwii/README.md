# 3AHWII SWP OOP (C#)

## 2026-02-24

Intensive Beschäftigung mit Opencode.ai

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
