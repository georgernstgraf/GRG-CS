namespace BruchName;

public class Bruch
{
    // jetzt kommen die sog. "Attribute" der Klasse oder "Felder"
    private int _ganz;
    private int _nenner;
    private int _zaehler;

    public Bruch(string bruchtext)
    // Anforderungen
    // 1. "3" oder auch "7/8" sollen möglich sein, zusätzlich zu "2 5/18"
    // bei jedem anderen String soll eine Exception geworfen werden
    // Alle diese Fälle in der Testklasse abbilden!!
    {
        if (string.IsNullOrWhiteSpace(bruchtext))
        {
            throw new ArgumentException("Die Eingabe darf nicht leer sein.");
        }

        var teileLeerzeichen = bruchtext.Trim().Split(' ');

        if (teileLeerzeichen.Length == 2)
        {
            if (!int.TryParse(teileLeerzeichen[0], out _ganz))
            {
                throw new ArgumentException("Der ganzzahlige Teil ist ungültig.");
            }
            ParseBruch(teileLeerzeichen[1]);
        }
        else if (teileLeerzeichen.Length == 1)
        {
            if (teileLeerzeichen[0].Contains('/'))
            {
                _ganz = 0;
                ParseBruch(teileLeerzeichen[0]);
            }
            else
            {
                if (!int.TryParse(teileLeerzeichen[0], out _ganz))
                {
                    throw new ArgumentException("Die Zahl ist ungültig.");
                }
                _zaehler = 0;
                _nenner = 1;
            }
        }
        else
        {
            throw new ArgumentException("Das Format ist ungültig. Erwartet: 'Ganzzahl Zähler/Nenner', 'Zähler/Nenner' oder 'Ganzzahl'.");
        }

        if (_nenner == 0)
        {
            throw new ArgumentException("Der Nenner darf nicht Null sein.");
        }

        this.Kürze();
    }

    private void ParseBruch(string bruchString)
    {
        var teileSchraegstrich = bruchString.Split('/');
        if (teileSchraegstrich.Length != 2 || 
            !int.TryParse(teileSchraegstrich[0], out _zaehler) || 
            !int.TryParse(teileSchraegstrich[1], out _nenner))
        {
            throw new ArgumentException("Der Bruch-Teil ist ungültig.");
        }
    }

    private Bruch(int ganz, int zaehler, int nenner)
    {
        if (nenner == 0)
        {
            throw new ArgumentException("Der Nenner darf nicht Null sein.");
        }

        _ganz = ganz;
        _zaehler = zaehler;
        _nenner = nenner;
        Kürze();
    }

    private void Kürze()
    {
        var g = Gcd(_zaehler, _nenner);
        _zaehler /= g;
        _nenner /= g;
        _ganz += _zaehler / _nenner;
        _zaehler %= _nenner;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public Bruch Addiere(Bruch b)
    {
        var a = this;
        return new Bruch(a._ganz + b._ganz, a._zaehler * b._nenner + b._zaehler * a._nenner, a._nenner * b._nenner);
    }

    public override string ToString()
    {
        if (_zaehler == 0) return $"{_ganz}";
        return $"{_ganz} {_zaehler}/{_nenner}";
        // JS: return `ich bin ein bruch: ${this.zaehler}/${this.nenner}`;
    }
}