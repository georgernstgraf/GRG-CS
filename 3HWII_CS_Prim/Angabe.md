# 3AHWII PLF5 28.4.2023

#### Themen: Decimal, Enum, Primzahlen, Algorithmik

### Beurteilungskriterien

Für ein Genügend müssen die Rechenergebnisse von Aufgabe 1 stimmen.

Für ein Befriedigend müssen die Rechenergebnisse von Aufgabe 2 stimmen.

Für ein Gut müssen die Rechenergebnisse von Aufgabe 3 stimmen.

Für ein Sehr gut muß NUR Aufgabe 4 RICHTIG gelöst werden.

### Aufgabe 1 Feststellen, ob eine Zahl eine Primzahl ist

Erstelle ein Projekt, welches das erste Kommandozeilenargument parst und in
einer Methode ermittelt, ob dieses eine Primzahl ist. Wenn nein, soll
angegeben werden, wodurch die Zahl teilbar ist.

Beispiel:

```text
> dotnet run 11
11 ist eine Primzahl

> dotnet run 10
10 ist durch 2 teilbar, daher keine Primzahl
```

### Aufgabe 2 

Erstelle ein Projekt, das das erste Kommandozeilenargument als `Decimal`
Datentyp parst und ermittelt, ob diese Zahl eine Primzahl ist. Wenn nicht,
so soll die *nächste* Primzahl ausgegeben werden!

Beispiel:

```text
> dotnet run 74
74 ist kein Primzahl, die nächste ist 79
```


### Aufgabe 3 Primzahlzwilling ab

Primzahlzwillinge sind 2 Primzahlen, deren Differenz 2 ergibt. Dein Programm
soll das Kommandozeilenargument als Datentyp `Decimal` parsen und ab dieser
Zahl den nächsten Primzahlzwilling ausgeben. Zusätzlich soll die Suche
insofern optimiert werden, als nur bis zur Quadratwurzel der gegeben Zahl
gesucht wird.

Beispiel:

```text
>dotnet run 1000
Der nächste Primzahlzwilling ab 1000 sind 1049 und 1051.
```

### Aufgabe 4 Mastermind

Gegeben ist ein halbfertiges Projekt "mastermind.zip", in welchem die
Bewertung eines Versuches errechnet werden soll (wieviel schwarze, wieviele
weiße Stecker).

Implementiere, die Klasse "Bewertung" fertig.

---

Gutes Gelingen!








