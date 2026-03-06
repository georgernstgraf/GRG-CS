# Lösungen - Wissenstest 3AHWII - C# Programmierung

**Datum:** 03.03.2026

---

## Teil A: Multiple Choice - Lösungen

### Frage 1
**Richtige Antwort:** Die Verwendung von KI-Agenten (wie Opencode.ai) zur Unterstützung bei der Softwareentwicklung

**Erklärung:** Agentic Coding bezeichnet den Einsatz von KI-gestützten Agenten, die Entwickler bei verschiedenen Aufgaben unterstützen: Code schreiben, debuggen, refactoren, dokumentieren und lernen. Im Unterricht wurde Opencode.ai als Beispiel für solch einen Agenten verwendet.

---

### Frage 2
**Richtige Antwort:** GitHub Models, Opencode Zen und OpenRouter

**Erklärung:** Laut README.md wurden diese drei Inference Provider besprochen:
- **GitHub Models:** Kostenloser Zugang zu verschiedenen Modellen über GitHub
- **Opencode Zen:** Der integrierte Provider von Opencode.ai
- **OpenRouter:** Aggregator für viele verschiedene Modelle verschiedener Anbieter

---

### Frage 3
**Richtige Antwort:** Open-Source Modelle sind öffentlich zugänglich und können selbst gehostet werden, Closed-Source Modelle sind proprietär und nur über APIs erreichbar

**Erklärung:**
- **Open-Source:** Modelle wie Llama, Mistral, Qwen sind öffentlich verfügbar. Man kann sie herunterladen, auf eigenen Servern hosten und anpassen.
- **Closed-Source:** Modelle wie GPT-4, Claude, Gemini sind proprietär. Man kann sie nur über APIs nutzen, hat keinen Einblick in die Architektur und kann sie nicht selbst hosten.

---

### Frage 4
**Richtige Antwort:** Comma Separated Values

**Erklärung:** CSV = Comma Separated Values (kommaseparierte Werte). Obwohl der Name "Comma" enthält, werden oft auch andere Trennzeichen wie Semikolon verwendet (besonders in deutschsprachigen Regionen wegen des Dezimalkommas). Siehe Folien/WAS_IST_CSV.md.

---

### Frage 5
**Richtige Antwort:** CsvHelper

**Erklärung:** Laut README.md (2026-01-07) und Folien/WAS_IST_CSV.md wird das NuGet-Package "CsvHelper" für das Einlesen von CSV-Dateien empfohlen. Es bietet Features wie automatisches Mapping auf Klassen, Typkonvertierung und Konfiguration von Delimitern.

---

### Frage 6
**Richtige Antwort:** Semikolon (;) oder Komma (,)

**Erklärung:** Das Trennzeichen hängt vom "Dialect" der CSV-Datei ab:
- **Komma (,):** Standard im englischsprachigen Raum
- **Semikolon (;):** Häufig im deutschsprachigen Raum, da das Komma als Dezimaltrennzeichen verwendet wird
- Auch Tabulator (TSV) oder Pipe sind möglich, aber weniger verbreitet.

---

### Frage 7
**Richtige Antwort:** Automatische Typkonvertierung und Mapping auf Klassen

**Erklärung:** CsvHelper bietet gegenüber manuellem String-Splitting:
- Automatisches Mapping von CSV-Spalten auf Klassen-Properties
- Automatische Typkonvertierung (z.B. string zu int, DateTime)
- Konfiguration von Delimitern, Encoding, Header-Optionen
- Validierung von Daten während des Einlesens
- Bessere Fehlerbehandlung

Manuelles Splitting mit `string.Split()` ist fehleranfälliger und erfordert mehr Boilerplate-Code.

---

### Frage 8
**Richtige Antwort:** Eine domänenspezifische Anweisung, die dem Agenten spezielle Fähigkeiten gibt (z.B. für .NET, React, etc.)

**Erklärung:** Skills in Opencode.ai sind spezialisierte Anweisungen/Kontexte für bestimmte Technologien oder Aufgabenbereiche. Beispiele:
- Ein .NET-Skill könnte Informationen über C# Konventionen, Projektstruktur und Best Practices enthalten
- Ein React-Skill würde React-spezifisches Wissen bereitstellen
Skills helfen dem Agenten, kontextsensitiver und präziser zu arbeiten.

---

### Frage 9
**Richtige Antwort:** Klare und präzise Anweisungen geben, Kontext bereitstellen und Ergebnisse überprüfen

**Erklärung:** Wichtige Best Practices beim Agentic Coding:
1. **Klare Prompts:** Spezifisch sein, nicht zu viel auf einmal fragen
2. **Kontext bereitstellen:** Dateien, Fehlermeldungen, Projektkontext teilen
3. **Iterativ arbeiten:** Schritt für Schritt vorgehen, nicht alles auf einmal
4. **Ergebnisse prüfen:** Generierten Code reviewen, Tests laufen lassen, nicht blind kopieren
5. **Feedback geben:** Dem Agenten mitteilen, wenn etwas nicht passt
6. **Lernen:** Die Vorschläge verstehen, nicht einfach akzeptieren

---

### Frage 10
**Richtige Antwort:** Es wird eine ArgumentException mit der Nachricht "Der Nenner darf nicht Null sein." geworfen

**Erklärung:** Dies ist ein Beispiel für defensives Programmieren. Der Konstruktor prüft explizit auf den ungültigen Zustand (Nenner = 0) und wirft eine aussagekräftige Exception, anstatt einen Fehler später im Code auftreten zu lassen.

---

### Frage 11
**Richtige Antwort:** `[Theory]` und `[InlineData]`

**Erklärung:** 
- `[Theory]` markiert einen parametrisierten Test
- `[InlineData]` liefert die Parameter für jeden Testfall
- `[Fact]` ist für einzelne, nicht-parametrisierte Tests

Beispiel:
```csharp
[Theory]
[InlineData("3 7/11", "3 7/11")]
[InlineData("0 15/10", "1 1/2")]
public void ToString_Normalizes_And_Formats(string input, string expected)
```

---

### Frage 12
**Richtige Antwort:** Ein Service, der Zugriff auf verschiedene KI-Modelle von verschiedenen Anbietern über eine einheitliche API bietet

**Erklärung:** OpenRouter ist ein Unified API für KI-Modelle:
- Ermöglicht Zugriff auf Modelle von OpenAI, Anthropic, Google, Meta und vielen anderen über eine einheitliche Schnittstelle
- Nutzer brauchen nur einen API-Key
- Einfacher Modell-Wechsel möglich
- Pay-as-you-go Preismodell

---

## Teil B: Freitext-Fragen - Musterlösungen

### Frage 13: Agentic Coding - Best Practices (5 Punkte)

**Musterlösung:**

**1. Klare und präzise Prompts formulieren (1,5 Punkte)**
- Spezifisch sein: Statt "mach das besser" lieber "füge eine Validierung hinzu, die prüft ob die Eingabe eine positive Zahl ist"
- Kontext geben: Was soll erreicht werden, welche Technologie wird verwendet
- Einzelne Aufgaben statt alles auf einmal: Schritt für Schritt vorgehen
- Beispiele: "Erstelle eine C# Klasse Bruch mit den Eigenschaften Zähler und Nenner"

**2. Kontext bereitstellen (1,5 Punkte)**
- Der Agent hat keinen Zugriff auf das ganze Projekt ohne explizite Mitteilung
- Relevante Dateien teilen: "Hier ist die aktuelle Bruch.cs Datei..."
- Fehlermeldungen kommunizieren: "Ich bekomme folgenden Fehler: ..."
- Projektstruktur erklären: "Es handelt sich um ein .NET 8.0 Konsolenprojekt mit xUnit Tests"
- Framework/Libraries nennen: "Wir verwenden CsvHelper für CSV-Dateien"

**3. Ergebnisse überprüfen (2 Punkte)**
- **Nicht blind kopieren:** Der generierte Code kann Fehler enthalten
- **Review:** Code lesen und verstehen, bevor er übernommen wird
- **Testen:** Unittests schreiben und ausführen (z.B. mit `dotnet test`)
- **Build:** Projekt kompilieren lassen (`dotnet build`)
- **Lernen:** Die Vorschläge als Lerngelegenheit nutzen, nicht als Abkürzung
- **Iterieren:** Wenn etwas nicht passt, Rückmeldung geben und verbessern lassen
- **Sicherheit:** Keine sensiblen Daten (Passwörter, Keys) im Prompt teilen

---

### Frage 14: CSV-Verarbeitung mit CsvHelper (5 Punkte)

**Musterlösung:**

**1. Modellklasse erstellen (1,5 Punkte)**

Zuerst benötigt man eine Klasse, die die Struktur der CSV-Daten abbildet:

```csharp
public class Person
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public string Adresse { get; set; }
}
```

- Properties sollten den Spaltennamen im CSV entsprechen (oder mit Attributen gemappt werden)
- Datentypen anpassen (string, int, DateTime, etc.)

**2. CsvReader konfigurieren und Datei öffnen (1,5 Punkte)**

```csharp
using var reader = new StreamReader("persons.csv");
using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
{
    Delimiter = ";",  // Wichtig für deutsche CSV-Dateien
    HasHeaderRecord = true,  // Erste Zeile enthält Spaltennamen
    Encoding = Encoding.UTF8
});
```

- StreamReader öffnet die Datei
- CsvConfiguration definiert den Dialect (Delimiter, Encoding, Header)
- `using` stellt sicher, dass Ressourcen freigegeben werden

**3. Daten einlesen und ausgeben (2 Punkte)**

```csharp
// Option A: Automatisches Mapping
var records = csv.GetRecords<Person>();
foreach (var person in records)
{
    Console.WriteLine($"{person.Fullname}: {person.Email}");
}

// Option B: Manuelles Auslesen (ohne Klasse)
csv.Read();  // Header überspringen
while (csv.Read())
{
    var name = csv.GetField<string>(0);  // Index-basiert
    var email = csv.GetField<string>("Email");  // Name-basiert
    Console.WriteLine($"{name}: {email}");
}
```

- `GetRecords<T>()` mappt automatisch auf die Klasse
- `csv.Read()` liest die nächste Zeile
- `GetField()` liest einzelne Felder (index- oder name-basiert)
- Iteration mit foreach oder while

**Alternative für Array (wie in der Hausübung erwähnt):**
```csharp
var personen = csv.GetRecords<Person>().ToArray();
```

---

### Frage 15: Open-Source vs. Closed-Source KI-Modelle (5 Punkte)

**Musterlösung:**

**1. Kostenaspekte (1 Punkt)**

**Open-Source:**
- **Vorteile:** Keine Lizenzkosten für das Modell selbst
- **Nachteile:** Hardware-Kosten für Self-Hosting (GPU-Server), Betriebskosten

**Closed-Source:**
- **Vorteile:** Pay-per-use, keine Investition in Hardware nötig, kostenlose Tiers oft verfügbar (z.B. GitHub Models)
- **Nachteile:** Bei hoher Nutzung können Kosten schnell steigen, Abhängigkeit vom Anbieter

**2. Datenschutz und Datensouveränität (1,5 Punkte)**

**Open-Source:**
- **Vorteile:** Daten bleiben auf eigenen Servern (Self-Hosting), keine Übertragung zu externen Anbietern, ideal für sensitive Daten (Banken, Behörden, Gesundheitswesen)
- **Nachteile:** Verantwortung für Sicherheit liegt beim Betreiber

**Closed-Source:**
- **Vorteile:** Professionelle Sicherheitsmaßnahmen des Anbieters, Compliance-Zertifizierungen
- **Nachteile:** Daten werden an externe Server gesendet, mögliche Speicherung/Verarbeitung durch Anbieter, weniger Kontrolle über Datenfluss

**3. Qualität und Performance (1,5 Punkte)**

**Open-Source:**
- **Vorteile:** Große Auswahl, schnelle Innovation durch Community, spezialisierte Modelle verfügbar
- **Nachteile:** Top-Performance-Modelle (GPT-4, Claude) oft besser als Open-Source-Alternativen, Qualität variiert stark zwischen Modellen

**Closed-Source:**
- **Vorteile:** Oft State-of-the-Art Performance (besonders bei großen Modellen), konsistente Qualität, professioneller Support
- **Nachteile:** Weniger Transparenz über Trainingsdaten und Architektur, Black-Box

**4. Anpassungsmöglichkeiten (1 Punkt)**

**Open-Source:**
- **Vorteile:** Volle Kontrolle: Fine-Tuning auf eigene Daten, Modifikation der Architektur, Integration in bestehende Systeme, keine API-Limitationen
- **Nachteile:** Erfordert technisches Know-how

**Closed-Source:**
- **Vorteile:** Einfache Integration über APIs, standardisierte Schnittstellen
- **Nachteile:** Keine Anpassung des Modells selbst möglich, nur Prompt-Engineering, abhängig von API-Limitationen (Rate Limits, verfügbare Features)

**Fazit/Empfehlung:**
- Für Learning/Experimentieren: Closed-Source (einfacher Einstieg)
- Für Produktion mit sensiblen Daten: Open-Source (Self-Hosting)
- Für Budget-kritische Projekte: Open-Source oder GitHub Models (kostenlos)

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
