# 1. Einheit: Profi-Setup – WSL, GnuPG, PASS & Der Agent als Keyholder

**Datum:** 08. Juni 2026

## 1. Das Fundament: Linux im Terminal (15 Min)

Moderne Backend-Entwicklung findet (fast) immer auf Linux statt. Damit wir alle die gleichen Werkzeuge nutzen können, brauchen wir einheitliche Terminals.

* **Windows (WSL):**
    Wir nutzen das **Windows Subsystem for Linux**.
    *Befehl:* `wsl --install` in einer Administrator-PowerShell.
* **Mac (Homebrew):**
    Apple basiert auf Unix, aber wir brauchen den Paketmanager `brew`.
    *Befehl:* `/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"`

---

## 2. Kryptografie Basics: GnuPG (15 Min)

Wie beweisen wir online unsere Identität und wie halten wir Geheimnisse wirklich geheim?
Die Antwort: **Asymmetrische Verschlüsselung**.

* **Public Key (Öffentlicher Schlüssel):** Wie ein offenes Vorhängeschloss. Jeder darf es haben und damit Nachrichten an dich verschließen.
* **Private Key (Privater Schlüssel):** Der einzige Schlüssel, der das Schloss wieder aufbekommt. Dieser bleibt *immer* und *ausschließlich* bei dir!

**Übung:** Generiere dein GnuPG (GPG) Schlüsselpaar:

```bash
gpg --full-generate-key
```

*(Wähle RSA, 4096 bit, Name und deine echte Schul-E-Mail).*

---

## 3. PASS – Der Passwortmanager der Profis (30 Min)

`pass` ist der Standard-Unix-Passwortmanager. Er speichert Passwörter nicht in einer ominösen Cloud, sondern als simple Textdateien, die mit **GPG verschlüsselt** sind.

**Warum `pass`?**

1. **Multi-Client & Multi-Tenant:** Wir legen den Passwort-Ordner in ein Git-Repository. So können wir Passwörter sicher zwischen Laptop und Handy (Mobile Apps!) synchronisieren.
2. **Der Agent als Keyholder:** (💡 *Empfohlenes Video:* [AI Agents and Pass/GPG](https://youtu.be/joUIdxPOrZY?si=TkxaBCshhe8Vz4_5))
Wir können Passwörter nicht nur für uns selbst, sondern für *spezifische Schlüsselhalter* verschlüsseln. In Zukunft autorisieren wir unseren KI-Agenten über seinen Public Key, damit dieser sicher und autonom an Datenbank-Credentials herankommt!

---

## 4. Klassenübung: Key-Signing Party & Git Sync (40 Min)

*Wir bauen unser "Web of Trust"!*

**Schritt 1: Public Key exportieren & hochladen**

1. Lass dir deinen Fingerprint (die lange Zeichenkette) anzeigen: `gpg --list-keys`
2. Lade deinen Public Key auf einen Keyserver hoch (ersetze `KEY_ID` durch die letzten 8 Zeichen deines Fingerprints):
   `gpg --keyserver keyserver.ubuntu.com --send-keys KEY_ID`
3. **Schreibe deinen Fingerprint auf einen Zettel!**

**Schritt 2: Die Party!**
Tauscht eure Zettel aus. Wenn du den Zettel von Max Mustermann hast:

1. Suche seinen Key: `gpg --keyserver keyserver.ubuntu.com --search-keys max.mustermann@student.grg.at`
2. **Wichtig:** Vergleiche den angezeigten Fingerprint mit dem auf dem Zettel!
3. Wenn er stimmt, signiere ihn: `gpg --sign-key SEINE_KEY_ID`
4. Lade den signierten Key wieder hoch: `gpg --keyserver keyserver.ubuntu.com --send-keys SEINE_KEY_ID`

**Schritt 3: Git-Passwort-Store initialisieren**

```bash
pass init "Deine E-Mail-Adresse"
pass git init
```

---

## 📝 Hausübung

1. Lade dir eine kompatible Password-Manager-App für dein Smartphone herunter (z.B. **Password Store** für Android oder **Pass** für iOS).
2. Synchronisiere dein in der Schule erstelltes Git-Passwort-Repo mit deinem Handy. (Erstelle dazu z.B. ein privates GitHub/GitLab Repo als `origin` in deinem lokalen `pass` Verzeichnis).
