# 09. Kryptografie, GnuPG und PASS

## Das Problem des sicheren Schlüsselaustauschs
Im Internet stehen wir vor einem fundamentalen Problem: Wie kann ich jemandem eine geheime Nachricht schicken, ohne dass jemand anderes auf dem Weg dorthin mitliest? 

Stellen wir uns vor, wir verwenden eine verschließbare Kiste. Wenn ich die Kiste mit einem Schloss verschließe und an dich schicke, brauchst du den Schlüssel, um sie zu öffnen. Aber wie schicke ich dir den Schlüssel? Wenn ich den Schlüssel per Post (oder unverschlüsselt über das Internet) schicke, könnte ihn jemand abfangen, nachmachen und später unsere Kiste öffnen. 
Dieses Problem nennt man das **Schlüsselaustauschproblem** der *symmetrischen Verschlüsselung* (bei der derselbe Schlüssel zum Ver- und Entschlüsseln benutzt wird).

---

## Die Lösung: Asymmetrische Verschlüsselung
Die Lösung ist genial und bildet das Fundament unserer modernen, sicheren Kommunikation (HTTPS, SSH, etc.): **Die Asymmetrische Verschlüsselung**.

Anstatt eines Schlüssels generieren wir ein zusammenhängendes **Schlüsselpaar**:
1.  **Den Public Key (Öffentlicher Schlüssel):** Stell dir das wie ein offenes Vorhängeschloss vor. Jeder darf dieses Schloss haben. Jeder kann dieses Schloss an eine Kiste hängen und diese zuklicken (verschlüsseln).
2.  **Den Private Key (Privater Schlüssel):** Das ist der einzige Schlüssel auf der Welt, der dieses spezifische Schloss wieder öffnen (entschlüsseln) kann. Dieser Schlüssel darf deinen Computer niemals verlassen.

### Wie funktioniert der Austausch nun?
1. Du möchtest eine geheime Nachricht von mir empfangen.
2. Du schickst mir dein *offenes Vorhängeschloss* (deinen Public Key). Das kann völlig ungesichert über das Internet passieren – es ist ja nur das offene Schloss.
3. Ich lege meine Nachricht in die Kiste, klicke *dein* Schloss zu und schicke die Kiste an dich zurück.
4. **Das Wichtige:** Selbst ich, der die Kiste gerade verschlossen hat, kann sie nun nicht mehr öffnen! Nur *du* mit deinem Private Key kannst das.

---

## Der Key-Server: Warum man Geheimnisse in die Welt hinausschreit
Es ist nicht nur sicher, sondern **zwingend notwendig**, seinen Public Key (das Vorhängeschloss) weiträumig zu verteilen. Wenn ihn niemand hat, kann dir auch niemand eine verschlüsselte Nachricht schicken.

Dafür gibt es **Key-Server** (z.B. `keyserver.ubuntu.com`). Das sind riesige, öffentliche Telefonbücher für Vorhängeschlösser. Du kannst dort nach der E-Mail-Adresse einer Person suchen und dir ihr Vorhängeschloss herunterladen.

---

## Identität und das "Web of Trust"
Hier entsteht das nächste Problem: Wenn ich auf dem Key-Server nach "Max Mustermann" suche, finde ich vielleicht drei verschiedene Vorhängeschlösser. Woher weiß ich, welches wirklich dem echten Max gehört und nicht einem Betrüger, der sich als Max ausgibt?

**Der Fingerprint (Fingerabdruck):**
Jeder Public Key hat einen kryptografischen Fingerabdruck – eine lange Zeichenfolge, die den Schlüssel eindeutig identifiziert (z.B. `2F9B 8A12 ...`).

**Das Web of Trust (Netz des Vertrauens):**
Anstatt einer zentralen Behörde zu vertrauen, vertrauen wir uns gegenseitig. 
1. Max und ich treffen uns physisch. Er zeigt mir seinen Ausweis und gibt mir einen Zettel mit seinem Fingerprint.
2. Ich lade den Key für Max vom Key-Server herunter.
3. Ich vergleiche den Fingerprint aus dem Internet mit dem Fingerprint auf dem echten Zettel.
4. Wenn sie übereinstimmen, **signiere** ich seinen Schlüssel mit *meinem* Private Key. Das ist wie mein digitaler Stempel: "Ich bürge dafür, dass dieser Schlüssel wirklich Max gehört."

Wenn meine Freunde nun Max eine Nachricht schicken wollen und sehen, dass *ich* (dem sie bereits vertrauen) für Max gebürgt habe, können sie sicher sein, den richtigen Schlüssel zu verwenden.

---

## Architektur von PASS
**PASS** (`pass`) ist der Standard-Unix-Passwortmanager, der auf genau dieser asymmetrischen Verschlüsselung basiert.

Anstatt Passwörter einer Firma (wie LastPass oder 1Password) in der Cloud anzuvertrauen, nutzt PASS eine viel simplere, aber sicherere Architektur:
*   Jedes Passwort wird als simple Textdatei auf deiner Festplatte gespeichert.
*   Bevor die Datei gespeichert wird, verschlüsselt `pass` sie mit GPG (und deinem Public Key).
*   Um das Passwort zu lesen, entschlüsselt `pass` die Datei kurzzeitig mit deinem Private Key.

### Die Vorteile der PASS-Architektur:
1.  **Git-Integration:** Da es nur Textdateien (wenn auch verschlüsselt) sind, lassen sie sich perfekt in einem Git-Repository verwalten (`pass git init`). So kannst du deine Passwörter versionieren und sicher über einen Git-Server (z.B. GitHub) zwischen deinem Laptop und Smartphone synchronisieren.

---

## Verschlüsselung für mehrere Empfänger (Multi-Recipient)
Ein häufig unterschätztes Feature von PGP/GPG: **Ich kann dieselbe Datei gleichzeitig für mehrere Personen verschlüsseln.**

PGP macht das technisch so: Es generiert einen zufälligen, symmetrischen **Session-Key**, mit dem die eigentliche Datei (die Klartext-Nachricht) verschlüsselt wird. Diesen Session-Key verschlüsselt PGP dann *einmal mit meinem Public Key* und *einmal mit deinem Public Key*. Beide verschlüsselten Session-Keys werden einfach an die Datei angehängt.

Wenn du die Datei öffnest, probiert dein Private Key die Schlösser durch – eines davon ist deines – und holt den Session-Key heraus. Genauso kann ich mit meinem Private Key dasselbe tun. Die Datei ist für beide lesbar, ohne dass wir einander unseren Private Key verraten müssen.

`pass` nutzt dieses Feature, indem du beim Initialisieren mehrere Keys angibst:

```bash
pass init "georg@schule.at" "agent@ai.local"
```

Das schreibt in die Datei `~/.password-store/.gpg-id`:
```
georg@schule.at
agent@ai.local
```

Von nun an wird **jede** neue Passwort-Datei so mit GPG verschlüsselt, dass sie **beide** Private Keys entschlüsseln können.

---

## Feingranulare Rechtevergabe: `.gpg-id` in Unterordnern
Das ist das geniale Konzept, um einem Agenten nur ein **Teilset** der Passwörter zugänglich zu machen.

Der Befehl `pass init -p` erlaubt es, **pro Unterordner** eine eigene `.gpg-id`-Datei anzulegen – mit anderen Schlüsseln als die Wurzel:

```bash
# Root: ALLES ist nur für mich lesbar
pass init "georg@schule.at"

# Aber im Ordner "Agent-Secrets": Ich UND der Agent können lesen
pass init -p Agent-Secrets "georg@schule.at" "agent@ai.local"
```

Das erzeugt folgende Verzeichnisstruktur:
```
~/.password-store/
├── .gpg-id               → Inhalt: "georg@schule.at"
├── Privat/
│   └── Banking.gpg       → verschlüsselt NUR für georg@schule.at
└── Agent-Secrets/
    ├── .gpg-id            → Inhalt: "georg@schule.at\nagent@ai.local"
    └── Datenbank.gpg      → verschlüsselt für georg@schule.at UND agent@ai.local
```

**Die Regel:** `pass` sucht beim Verschlüsseln immer die nächstgelegene `.gpg-id`-Datei – zuerst im aktuellen Unterordner, dann weiter oben, bis zum Wurzelverzeichnis. Die Datei im Unterordner überschreibt also die globale Einstellung.

### Praktisches Beispiel: Der KI-Agent als Keyholder
1. Du hast sensible Passwörter (Bank, private E-Mails) – die liegen im Root und in Ordnern ohne eigene `.gpg-id`. Nur du kannst sie lesen.
2. Du hast Passwörter für den Agenten (Datenbank-Credentials, API-Keys für ein Testsystem) – die liegen im Ordner `Agent-Secrets/`. Der Agent hat einen eigenen GPG-Key und kann sie lesen, weil sein Fingerprint in der `.gpg-id` des Unterordners steht.
3. Wenn der Agent kompromittiert wird, löschst du einfach seine Zeile aus der `.gpg-id` und re-encryptest den Ordner – deine privaten Passwörter waren nie in Gefahr.

**Fazit:** Keine zentrale Benutzerverwaltung, keine komplizierte ACL-Engine, keine zusätzliche Software. Nur das Dateisystem, GPG und `.gpg-id`-Dateien. Das ist die Eleganz von `pass`.

---

## Zugriff entziehen & Schlüsselrotation
Einem Keyholder den Zugang zu entziehen ist ein zweischneidiges Schwert.

### Was `pass` kann: Re-Encryption
Entfernt man einen Key aus der `.gpg-id` und führt `pass init -p Agent-Secrets "georg@schule.at"` erneut aus, verschlüsselt `pass` **alle betroffenen Dateien neu** – der entfernte Key ist ab sofort nicht mehr in den Chiffraten enthalten. Neue Geheimnisse kann der ausgesperrte Keyholder nicht lesen.

### Was `pass` nicht kann: Vergangenheit ungeschehen machen
**Git merkt sich alles.** Ein entfernter Keyholder mit noch vorhandenem Git-Zugriff kann per `git checkout` einen alten Commit auschecken, in dem die `.gpg`-Dateien noch mit seinem Public Key mitverschlüsselt waren. Sein Private Key existiert noch – also liest er die alten Secrets.

### Die einzig saubere Lösung: Schlüsselrotation
Weil Kryptografie niemals rückwirkend wirkt, muss man die **Geheimnisse selbst** rotieren:
- Datenbank-Passwort ändern
- API-Keys neu generieren
- Alles, was der ehemalige Keyholder je entschlüsselt hat, als kompromittiert betrachten

Danach ist der Inhalt alter Chiffrate wertlos – egal wer sie entschlüsseln kann.

**Merksatz:** `pass` kontrolliert den Zugriff auf Chiffrate, nicht auf Geheimnisse. Wenn das Vertrauen endet, endet auch die Gültigkeit der Geheimnisse.