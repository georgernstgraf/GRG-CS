# Klassenanalyse Wissensueberpruefung 3AHWII

**Datum:** 2026-03-04

## Gesamtbild

- Es wurden 12 gueltige Abgaben bewertet; bei mehrfacher Abgabe wurde jeweils nur die hoechste Version beruecksichtigt.
- Der Multiple-Choice-Teil wurde von den meisten sicher geloest; haeufigere Fehler traten bei Frage 1, Frage 4 und Frage 11 auf.
- Die groessten Leistungsunterschiede entstanden im Freitextteil: Vollstaendigkeit, fachliche Praezision und konkrete Nennung von APIs/Konfigurationsschritten waren ausschlaggebend.

## Haeufige Muster

- Mehrere Abgaben beschreiben Agentic Coding sinnvoll, bleiben aber bei der Begruendung von Kontext und der Pflicht zur Codepruefung zu allgemein.
- Beim Thema CsvHelper wurden Modellklasse und foreach oft genannt, die konkrete Konfiguration von `CsvReader` bzw. `CsvConfiguration` mit Delimiter, Header und Kultur aber teilweise ausgelassen.
- Bei Open-Source vs. Closed-Source wurden Kosten und Datenschutz meist erkannt; Unterschiede bei Qualitaet, Performance und Anpassbarkeit wurden teilweise nur kurz angerissen.
- Einzelne Abgaben enthielten kaum oder keine Freitextantworten; diese fehlende Ausarbeitung wirkte sich staerker aus als kleine Fehler im Multiple-Choice-Teil.

## Empfehlungen fuer den Unterricht

- Die Konfiguration von `CsvHelper` noch einmal praktisch wiederholen: `StreamReader`, `CsvReader`, `CsvConfiguration`, Delimiter, Header und Iteration in einem kompakten Beispiel.
- Bei Agentic Coding die Erwartung an gute Antworten schaerfen: klare Prompts, relevanter Projektkontext und verpflichtende Verifikation durch Lesen, Build und Tests.
- xUnit-Attribute (`[Theory]`, `[InlineData]`) sowie typische Distraktoren aus anderen Testframeworks kurz wiederholen.
- Bei Vergleichsfragen ein Antwortschema trainieren, das alle geforderten Kriterien sichtbar abdeckt, damit keine Teilaspekte vergessen werden.

## Anonyme Statistik

- Notenverteilung: 9x Sehr Gut, 0x Gut, 0x Befriedigend, 2x Genuegend, 1x Nicht Genuegend.
- Durchschnitt: 22.71 von 27 Punkten.
