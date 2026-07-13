# GRG-CS – SWP / OOP an der HTL Spengergasse

Unterrichtsrepository für das Fach **Softwareentwicklung und Projektmanagement (SWP)** –
**Objektorientierte Programmierung mit C#** – Klasse **3AHWII**, Abteilung Informationstechnologie.

---

## Übersicht

Dieses Repository enthält sämtliche während des Unterrichts erarbeiteten Projekte,
Hausübungen, Tests und Lehrmaterialien. Die Projekte sind chronologisch nach
Schuljahren und Themen geordnet.

---

## Beurteilung

Die Note setzt sich aus drei gleich gewerteten Bereichen zusammen:

| Bereich | Gewicht |
|---|---|
| PLF (Praxis-Leistungs-Feststellung) | 1/3 |
| Hausübungen | 1/3 |
| Mitarbeit | 1/3 |

Mitarbeit umfasst auch Schulübungen und Stundenwiederholungen; deren Qualität und
Intensität werden von der Lehrperson beurteilt.

## Hausübungen

- **Abgabe:** spätestens am nächsten Unterrichtstag **00:00 Uhr** (in der Regel eine Woche später).
- **Nachreichung:** jederzeit möglich – die erreichte Punktezahl zählt **75 %**.
- **Cutoff:** Genau **eine Woche vor dem Notenschluss, 00:00 Uhr**, ist Endtermin.
  Danach werden die Repos automatisiert ausgewertet.

## Organisatorisches

- **Toilettengang:** wortlos aufstehen, Blickkontakt mit der Lehrperson.
- **Rückmeldung** zu automatisierten E-Mails und nachgereichten Arbeiten bitte als
  Antwort auf das Roboter-E-Mail.

---

## Projekte

| Ordner | Beschreibung |
|---|---|
| `3ahwii/2025-11_Bruch/` | Bruch-Klasse mit Operatoren, Parsing, xUnit-Tests – Einstieg in OOP |
| `3ahwii/2026-02-08_CSV/` | CSV-Verarbeitung mit CsvHelper |
| `3ahwii/2026-03-04_Test/` | Knowledge-Check / Test |
| `3ahwii/2026-03-25_stundenWH/` | Stundenwiederholung: Arrays, List, Dictionary, HashSet (Kap. 10) |
| `3ahwii/2026-04-15_Inference/` | AI/LLM Inference Provider in opencode.ai |
| `3ahwii/2026-05-20_rest/` | REST-Client, HTTP-Protokoll |
| `2023_Mastermind/` | PLF-Prüfungsbeispiel: Mastermind-Bewertung, Enum, Primzahlen |
| `2023_Webserver/` | Einfacher ASP.NET Core Webserver mit Static Files und API-Endpoint |
| `2025_Backend_SQLite_Partials/` | ASP.NET Core MVC + EF Core + SQLite (OpenTDB-Quiz) mit Partial Views und Paginierung |
| `2025_Blazor/` | Blazor-Projekt mit interaktivem Server-Side Rendering (Todo-Liste) |
| `2025_WCF_Pokemon_proxy/` | ASP.NET Core Web API als Proxy zur PokeAPI |

---

## Themenübersicht (Lehrplan 3AHWII)

- **Grundlagen:** Datentypen, Kontrollstrukturen, Methoden, Debugging
- **OOP:** Klassen, Vererbung, Interfaces, Properties, Operator Overload
- **Collections:** Arrays, `List<T>`, `Dictionary<TKey,TValue>`, `HashSet<T>`
- **Fehlerbehandlung:** `try`/`catch`/`throw`, Fail-Fast-Prinzip
- **Unit-Tests:** xUnit, Assertions, Random-Tests
- **Dateiverarbeitung:** CSV mit CsvHelper
- **Webentwicklung:** ASP.NET Core (MVC, Web API, Blazor, Static Files, Razor Components)
- **Datenbanken:** Entity Framework Core, SQLite, LINQ
- **API-Integration:** REST-Client, HttpCLient, externe APIs (OpenTDB, PokeAPI)
- **Agentic Coding:** opencode.ai, Inference Provider (GitHub Models, OpenRouter, opencode Zen)
- **Git:** Versionsverwaltung, Commit-Konventionen

---

## Ordnerstruktur

```
GRG-CS/
├── 3ahwii/                    # Aktuelles Unterrichtsjahr (3AHWII)
│   ├── 2025-11_Bruch/         # Bruch-Projekt mit Tests
│   ├── 2026-02-08_CSV/        # CSV-Einschulung
│   ├── 2026-03-04_Test/       # Knowledge-Check
│   ├── 2026-03-25_stundenWH/  # Stundenwiederholung
│   ├── 2026-04-15_Inference/  # AI Inference
│   ├── 2026-05-20_rest/       # REST-Client
│   ├── Hausübungen.md         # Alle Hausübungen im Detail
│   ├── POJEKTE.md             # Blazor-Projektideen
│   ├── CLASS.md               # Klassenbeobachtungen
│   ├── RULEZ.md               # Beurteilungsrichtlinien
│   └── README.md              # Unterrichts-Chronik
├── 2023_Mastermind/           # PLF-Prüfung (Mastermind)
├── 2023_Webserver/            # ASP.NET Core Einstieg
├── 2025_Backend_SQLite_Partials/ # MVC + EF Core + SQLite
├── 2025_Blazor/               # Blazor Server App
├── 2025_WCF_Pokemon_proxy/    # Web API Proxy
├── Folien/                    # Unterrichtsfolien
├── docs/ai/                   # KI-Agenten-Konfiguration
├── grg-cs.sln                 # Visual Studio Solution
├── skriptum.pdf               # Skriptum (OOP C#)
└── AGENTS.md                  # AI-Agenten-Anweisungen
```

---

## Lizenz

Unterrichtsmaterial – zur Verfügung gestellt für den Einsatz an der HTL Spengergasse.
