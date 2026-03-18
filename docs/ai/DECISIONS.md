# Decisions

Architectural and technical decisions made in this project.
Each entry documents WHAT was decided and WHY.

## 2026-03-18: PDF-Extraktion mit pdftotext
- **Choice**: pdftotext für das Lesen von skriptum.pdf verwenden
- **Reason**: Das Modell kann PDFs nicht direkt lesen; pdftotext ist zuverlässig verfügbar
- **Considered**: Direktes PDF-Lesen (nicht unterstützt)
- **Tradeoff**: Formatierung geht verloren, aber Textinhalt ist vollständig

## 2026-03-18: Hausübungsthemen aus README.md
- **Choice**: Aktuelle Themen aus 3ahwii/README.md für Hausübungen extrahieren
- **Reason**: README.md wird aktuell gehalten und spiegelt den Unterrichtsstand wider
- **Considered**: Manuelles Nachfragen bei jedem Hausübungstermin
- **Tradeoff**: Keine - README.md ist die korrekte Quelle
