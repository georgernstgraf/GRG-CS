# Klassenanalyse – Knowledge Check 3AHWII

**Datum:** 24.03.2026
**Themen:** Interfaces, ref/out, Strings, Schleifen (break/continue), ENUM, Fail Fast

---

## Statistische Übersicht

| Kennzahl | Wert |
|----------|------|
| Teilnehmer | 12 |
| Durchschnitt | 71,5 Punkte (84,1%) |
| Median | 79 Punkte |
| Bestanden (≥51 Punkte) | 10 (83,3%) |
| Nicht bestanden | 2 (16,7%) |
| Höchstpunkte | 5 Schüler (41,7%) |

---

## Häufige Fehler in den Multiple-Choice-Fragen

### Frage 1: Interfaces – Grundlagen
**Häufigkeit:** ~25% der Schüler machten Fehler
**Typische Fehler:**
- Option B nicht angekreuzt (Interface definiert nur Signaturen)
- Option A fälschlicherweise angekreuzt (Instanzfelder in Interfaces)

**Empfehlung:** Noch einmal betonen, dass Interfaces keine Instanzfelder enthalten können – nur Properties, Methoden und Events.

### Frage 5: ref vs out
**Häufigkeit:** ~17% der Schüler machten Fehler
**Typische Fehler:**
- Option A nicht angekreuzt (ref erfordert Initialisierung)
- Verwechslung der Semantik von ref und out

**Empfehlung:** Die Unterschiede zwischen ref und out anhand konkreter Codebeispiele wiederholen.

### Frage 7: StringBuilder
**Häufigkeit:** ~8% der Schüler machten Fehler
**Typische Fehler:**
- Option A fälschlicherweise angekreuzt (StringBuilder auch bei einmaliger Verkettung sinnvoll)

**Empfehlung:** Betonen, dass StringBuilder erst bei vielen Operationen effizient ist, nicht bei einmaliger Verkettung.

### Frage 9: continue in Schleifen
**Häufigkeit:** ~8% der Schüler machten Fehler
**Typische Fehler:**
- Option D fälschlicherweise angekreuzt (continue beendet die gesamte Schleife)
- Option C nicht angekreuzt (continue überspringt aktuellen Durchlauf)

**Empfehlung:** Den Unterschied zwischen break und continue anhand von Live-Demonstrationen im Unterricht zeigen.

### Frage 10: ENUM und Fail Fast
**Häufigkeit:** ~17% der Schüler machten Fehler
**Typische Fehler:**
- Option B nicht angekreuzt (Fail Fast Bedeutung)
- Option D nicht angekreuzt (Enums sind numerisch)

**Empfehlung:** Das Fail-Fast-Prinzip mit konkreten Beispielen (z.B. Argumentvalidierung am Methodenanfang) verdeutlichen.

---

## Häufige Fehler in den Freitextaufgaben

### Aufgabe 1: Interface entwerfen und implementieren

**Häufigkeit:** ~33% der Schüler hatten Schwierigkeiten
**Typische Fehler:**
- Interface-Name falsch geschrieben (z.B. `IFahrzeut` statt `IFahrzeug`)
- Methode falsch benannt (z.B. `Startermotor` statt `StarteMotor`)
- Property `Typ` in den Klassen nicht implementiert
- Fehlende Typdeklaration bei der List-Initialisierung
- Nur Erklärung ohne Code abgegeben

**Empfehlung:** Mehr Übungsaufgaben zur Interface-Implementierung mit Fokus auf korrekte Syntax und vollständige Implementierung aller Member.

### Aufgabe 2: ref und out – Fehler finden und korrigieren

**Häufigkeit:** ~25% der Schüler hatten Schwierigkeiten
**Typische Fehler:**
- Unvollständige Fehleridentifikation (nur 2-3 von 5 Fehlern gefunden)
- Korrigierter Code enthält noch Fehler (z.B. `a` nicht zugewiesen)
- Erklärung zu ref/out ungenau oder falsch

**Empfehlung:** Gemeinsame Code-Analyse im Unterricht mit Fokus auf Compilerfehlermeldungen. Schüler sollen lernen, Fehler systematisch zu identifizieren.

### Aufgabe 3: break und continue anwenden

**Häufigkeit:** ~8% der Schüler hatten Schwierigkeiten
**Typische Fehler:**
- Erklärung zu break/continue zu knapp oder unvollständig
- Einsatzszenarien nicht genannt oder nicht sinnvoll

**Empfehlung:** Diese Aufgabe wurde insgesamt sehr gut gelöst. Weiter so!

---

## Empfehlungen für den Unterricht

### Kurzfristig (nächste Wochen)

1. **Interfaces vertiefen:** Ein eigenes Übungsblatt mit Interface-Definitionen und Implementierungen. Fokus auf korrekte Syntax und vollständige Member-Implementierung.

2. **ref/out praktisch üben:** Live-Coding-Sessions, bei denen Schüler Fehler in Code finden und korrigieren müssen. Compilerfehlermeldungen analysieren.

3. **Nachbesprechung:** Die häufigsten Fehler aus dieser Wissensüberprüfung gemeinsam im Unterricht durchgehen.

### Mittelfristig (Rest des Schuljahres)

1. **Fail-Fast-Prinzip:** In zukünftigen Projekten konsequent anwenden und thematisieren.

2. **StringBuilder-Kontext:** Bei String-Operationen in Schleifen immer auf StringBuilder hinweisen.

3. **Code-Review:** Schüler gegenseitig Code reviewen lassen – das schärft das Auge für Fehler.

### Allgemein

- Die Klasse zeigt ein insgesamt gutes Verständnis der Themen
- 83,3% Bestehensquote ist gut, aber verbesserungsfähig
- Die beiden nicht bestandenen Schüler benötigen gezielte Nachhilfe
- Fokus auf genaues Lesen der Aufgabenstellungen und Multiple-Choice-Optionen
