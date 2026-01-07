# WAS ist CSV?

CSV = Comma Separated Values

## wichtige Begriffe

### Delimiter = Trennzeichen

was trennen die?

1) Werte in einer Zeile (Field Separator, z.B. , ; | \t ...)
2) Zeilen voneinander (Line Separator, meist \n (standard) oder \r\n (Windows) oder \r (Mac, alt))

### Record = Datensatz = eine Zeile

### Field = Feld (sql: Spalte)

### Header = Kopfzeile (optional)

### Encoding = Zeichensatz (UTF-8, ANSI, ...)

### Quote Character = Textbegrenzer (z.B. " ' ...)

### Escape Character = Escape Zeichen (z.B. \ )

### Dialect

Kombination aller Einstellungen (Delimiter, Quote Character, Escape Character, Header ja/nein, ...)

## Zugriff mit C #

CsvHelper NuGet Package
