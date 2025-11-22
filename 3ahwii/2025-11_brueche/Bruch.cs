namespace _2025_11_brueche;

internal class Bruch
{
    // jetzt kommen die sog. "Attribute" der Klasse oder "Felder"
    private int _ganz;
    private int _nenner;
    private int _zaehler;

    public Bruch(string bruchtext)
    {
        var teile1 = bruchtext.Split(' ');
        _ganz = int.Parse(teile1[0]);
        var teile = teile1[1].Split('/');
        _zaehler = int.Parse(teile[0]);
        _nenner = int.Parse(teile[1]);
    }

    private Bruch(int ganz, int zaehler, int nenner)
    {
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
        return $"{_ganz} {_zaehler}/{_nenner}";
        // JS: return `ich bin ein bruch: ${this.zaehler}/${this.nenner}`;
    }
}