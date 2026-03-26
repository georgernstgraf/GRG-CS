# Knowledge Check – 3AHWII – Lösungen

**Datum:** 24.03.2026  
**Themen:** Interfaces, ref/out, Strings, Schleifen (break/continue), ENUM, Fail Fast

---

## Teil 1: Multiple-Choice – Lösungen

### Frage 1: Interfaces – Grundlagen
- [ ] A) **Falsch** – Interfaces können keine Instanzfelder enthalten (nur Properties, Methoden, Events).
- [x] B) **Richtig** – Interfaces definieren nur Signaturen, keine Implementierung.
- [x] C) **Richtig** – Eine Klasse kann beliebig viele Interfaces implementieren.
- [x] D) **Richtig** – Alle Member müssen implementiert werden.

**Punkte:** B, C, D ankreuzen = 3 richtige + 1 korrekt nicht angekreuzt = 4/4

---

### Frage 2: Interfaces – Polymorphie
- [x] A) **Richtig** – Polymorphie: Liste vom Interface-Typ kann alle Implementierungen aufnehmen.
- [ ] B) **Falsch** – Man kann Interface-Methoden direkt aufrufen, Cast nur nötig für typspezifische Member.
- [x] C) **Richtig** – `foreach` ruft `BeschreibeDich()` auf jedem Objekt auf (Polymorphie).
- [ ] D) **Falsch** – Eine Klasse kann mehrere Interfaces implementieren.

**Punkte:** A, C ankreuzen = 4/4

---

### Frage 3: Interfaces vs. Klassen
- [x] A) **Richtig** – Abstrakte Klassen können implementierte Methoden haben.
- [x] B) **Richtig** – C# unterstützt nur einfache Vererbung bei Klassen, aber multiple Interfaces.
- [ ] C) **Falsch** – Interfaces können keine Konstruktoren definieren.
- [ ] D) **Falsch** – Interfaces können ebenfalls nicht instanziiert werden.

**Punkte:** A, B ankreuzen = 4/4

---

### Frage 4: `out`-Parameter
- [x] A) **Richtig** – `out`-Parameter muss zwingend zugewiesen werden vor Return.
- [ ] B) **Falsch** – `out` erfordert keine Initialisierung vor dem Aufruf (anders als `ref`).
- [x] C) **Richtig** – Typischer Anwendungsfall: mehrere Rückgabewerte.
- [ ] D) **Falsch** – `out` wird als Referenz übergeben (by reference).

**Punkte:** A, C ankreuzen = 4/4

---

### Frage 5: `ref` vs `out`
- [x] A) **Richtig** – `ref` erfordert Initialisierung, `out` nicht.
- [x] B) **Richtig** – `out` zwingt zur Zuweisung, `ref` nicht.
- [ ] C) **Falsch** – Sie haben unterschiedliche Semantik bei Initialisierung und Zuweisung.
- [x] D) **Richtig** – Beide übergeben die Variable als Referenz.

**Punkte:** A, B, D ankreuzen = 4/4

---

### Frage 6: String-Vergleich `==` vs `.Equals()`
- [x] A) **Richtig** – Der Compiler optimiert zur Kompilierzeit, beide verweisen auf denselben String.
- [x] B) **Richtig** – Inhaltlicher Vergleich ist identisch.
- [ ] C) **Falsch** – Bei Strings vergleicht `==` in C# den Inhalt (überladen), nicht die Referenz.
- [x] D) **Richtig** – Praktisch identisch bei Strings in C#.

**Punkte:** A, B, D ankreuzen = 4/4

---

### Frage 7: StringBuilder
- [ ] A) **Falsch** – Bei einmaliger Verkettung ist `+` ausreichend und oft schneller.
- [x] B) **Richtig** – Viele Operationen in Schleifen → StringBuilder spart Speicher.
- [x] C) **Richtig** – Effizientes Zusammenbauen in Puffer ohne neue Objekte.
- [ ] D) **Falsch** – Nur bei vielen Operationen sinnvoll, nicht immer.

**Punkte:** B, C ankreuzen = 4/4

---

### Frage 8: `break` in Schleifen
- [x] A) **Richtig** – Bei `i == 5` wird `break` ausgeführt, 5 wird nicht mehr ausgegeben.
- [ ] B) **Falsch** – 5 wird nicht ausgegeben, da `break` vor `WriteLine` steht.
- [x] C) **Richtig** – `break` beendet die Schleife sofort.
- [ ] D) **Falsch** – Schleife wird sofort beendet, nicht noch einmal durchlaufen.

**Punkte:** A, C ankreuzen = 4/4

---

### Frage 9: `continue` in Schleifen
- [x] A) **Richtig** – `i == 2` wird übersprungen, Ausgabe: 0, 1, 3, 4.
- [ ] B) **Falsch** – 2 wird nicht ausgegeben.
- [x] C) **Richtig** – `continue` springt zum nächsten Durchlauf.
- [ ] D) **Falsch** – `continue` beendet nur den aktuellen Durchlauf, nicht die Schleife.

**Punkte:** A, C ankreuzen = 4/4

---

### Frage 10: ENUM und Fail Fast
- [x] A) **Richtig** – Enums sind Wertetypen mit benannten Konstanten.
- [x] B) **Richtig** – Fail Fast: Fehler früh erkennen und werfen.
- [ ] C) **Falsch** – Fail Fast sammelt nicht, sondern bricht früh ab.
- [x] D) **Richtig** – Standardmäßig `int`, andere Typen möglich mit `: byte` etc.

**Punkte:** A, B, D ankreuzen = 4/4

---

## Teil 2: Freitext – Lösungen

### Aufgabe 1: Interface entwerfen und implementieren

**a) Interface-Definition (3 Punkte)**

```csharp
public interface IFahrzeug
{
    string Typ { get; }
    string StarteMotor();
}
```

Bewertung:
- 1 Punkt für korrektes `interface IFahrzeug`
- 1 Punkt für Property `Typ { get; }`
- 1 Punkt für Methode `StarteMotor()`

---

**b) Klassen-Implementierung (6 Punkte)**

```csharp
public class Auto : IFahrzeug
{
    public string Typ => "Auto";
    
    public string StarteMotor()
    {
        return "Motor läuft";
    }
}

public class Fahrrad : IFahrzeug
{
    public string Typ => "Fahrrad";
    
    public string StarteMotor()
    {
        return "Fahrräder haben keinen Motor";
    }
}
```

Bewertung:
- 2 Punkte pro Klasse (Vererbung, Properties, Methoden korrekt)
- -1 Punkt für fehlendes Interface in Vererbung
- -1 Punkt für falsche Rückgabewerte

---

**c) Listen-Code (3 Punkte)**

```csharp
List<IFahrzeug> fahrzeuge = new List<IFahrzeug>();
fahrzeuge.Add(new Auto());
fahrzeuge.Add(new Fahrrad());

foreach (var f in fahrzeuge)
{
    Console.WriteLine($"{f.Typ}: {f.StarteMotor()}");
}
```

Bewertung:
- 1 Punkt für `List<IFahrzeug>`
- 1 Punkt für Hinzufügen beider Fahrzeuge
- 1 Punkt für korrekte Schleife mit Ausgabe

---

**d) Erklärung (3 Punkte)**

Musterlösung:
> Es ist sinnvoll, beide Klassen in derselben Liste zu speichern, weil sie dasselbe Interface implementieren. Dadurch können wir sie einheitlich behandeln (Polymorphie) und gemeinsame Operationen wie das Ausgeben von `Typ` und `StarteMotor()` in einer einzigen Schleife durchführen, ohne den konkreten Typ zu kennen.

Bewertung:
- 1 Punkt für Erwähnung von Polymorphie
- 1 Punkt für einheitliche Behandlung
- 1 Punkt für konkretes Beispiel (Schleife)

---

### Aufgabe 2: `ref` und `out` – Fehler finden und korrigieren

**a) Fehler identifizieren (6 Punkte)**

| Zeile | Fehler | Erklärung |
|-------|--------|-----------|
| 5 | `int x;` ohne Initialisierung | `x` wird später mit `ref` verwendet → muss initialisiert sein |
| 8 | `Berechne(x, out y)` – `x` nicht initialisiert | `x` wird als `out` übergeben, aber `y` hat schon einen Wert (sollte `ref` sein oder `x` muss initialisiert sein) |
| 8 | Parameter-Reihenfolge/Typ | `Berechne` erwartet zwei `out`-Parameter, aber `x` ist nicht initialisiert |
| 10 | `Verdopple(ref x)` – `x` nicht initialisiert | `ref` erfordert Initialisierung |
| 15 | `b = a * 2;` – `a` nicht zugewiesen | `out`-Parameter `a` muss vor Verwendung zugewiesen werden |

Bewertung:
- Je 1-1,5 Punkte pro korrekt identifiziertem Fehler mit Erklärung

---

**b) Korrigierter Code (6 Punkte)**

```csharp
class Program
{
    static void Main()
    {
        int x = 5;      // Initialisiert für ref
        int y;          // out muss nicht initialisiert sein
        
        Berechne(out x, out y);  // beide out
        
        // Oder Alternative mit ref:
        // int x = 5;
        // int y = 10;
        // BerechneRef(ref x, ref y);
    }
    
    static void Berechne(out int a, out int b)
    {
        a = 10;         // out muss zugewiesen werden
        b = a * 2;
    }
}
```

Bewertung:
- 3 Punkte für korrekte Initialisierung
- 2 Punkte für korrekte Verwendung von `out`/`ref`
- 1 Punkt für korrekte Zuweisung in der Methode

---

**c) Erklärung (3 Punkte)**

Musterlösung:
> `ref` erfordert, dass die Variable vor dem Aufruf initialisiert ist, und die Methode muss den Wert nicht zwingend ändern. `out` erfordert keine Initialisierung vor dem Aufruf, aber die Methode muss der Variable zwingend einen Wert zuweisen, bevor sie zurückkehrt.

Bewertung:
- 1 Punkt für Initialisierungsunterschied
- 1 Punkt für Zuweisungspflicht
- 1 Punkt für klare Formulierung

---

### Aufgabe 3: `break` und `continue` anwenden

**a) break-Beispiel (5 Punkte)**

```csharp
string[] artikel = { "Apfel", "Banane", "Kiwi", "Orange", "Mango" };

foreach (var a in artikel)
{
    if (a == "Kiwi") break;
    Console.WriteLine(a);
}
```

Ausgabe: `Apfel` `Banane`

Bewertung:
- 2 Punkte für korrekte Schleife
- 2 Punkte für korrekte `break`-Bedingung
- 1 Punkt für korrekte Ausgabe

---

**b) continue-Beispiel (5 Punkte)**

```csharp
string[] artikel = { "Apfel", "Banane", "Kiwi", "Orange", "Mango" };

foreach (var a in artikel)
{
    if (a.Length <= 5) continue;
    Console.WriteLine(a);
}
```

Ausgabe: `Banane` `Orange`

Bewertung:
- 2 Punkte für korrekte Schleife
- 2 Punkte für korrekte `continue`-Bedingung (`a.Length <= 5` oder `a.Length < 6`)
- 1 Punkt für korrekte Ausgabe

---

**c) Erklärung (5 Punkte)**

Musterlösung:

**Unterschied:**
> `break` beendet die gesamte Schleife sofort und setzt mit dem Code nach der Schleife fort. `continue` beendet nur den aktuellen Durchlauf und fährt mit dem nächsten Schleifendurchlauf fort.

**Einsatzszenarien:**
- `break`: Suche abbrechen, wenn Element gefunden wurde (z.B. User in Liste suchen und bei Fund aufhören).
- `continue`: Bestimmte Elemente überspringen (z.B. nur gerade Zahlen verarbeiten, ungerade überspringen).

Bewertung:
- 2 Punkte für korrekten Unterschied
- 1,5 Punkte pro sinnvollem Einsatzszenario

---

## Punkteübersicht

| Teil | Max. Punkte |
|------|-------------|
| MC-Fragen | 40 |
| Aufgabe 1 | 15 |
| Aufgabe 2 | 15 |
| Aufgabe 3 | 15 |
| **Gesamt** | **85** |

---

## Notenschlüssel (Beispiel)

| Punkte | Note |
|--------|------|
| 77-85 | Sehr gut (1) |
| 68-76 | Gut (2) |
| 60-67 | Befriedigend (3) |
| 51-59 | Genügend (4) |
| 0-50 | Nicht genügend (5) |
