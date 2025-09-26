class Bewertung
{
    int Weisse {get;}
    int Schwarze { get;}
    Farbcode vorgabe, versuch;
    public Bewertung(Farbcode vorgabe, Farbcode versuch)
    {
        this.vorgabe = vorgabe;
        this.versuch = versuch;
    // TODO hier die Anzahl der Weissen und Schwarzen berechnen
    }
    public override string ToString()
    {
        return $"Versuch-{versuch} bekommt bei Vorgabe {vorgabe} {Schwarze} schwarze und {Weisse} weisse Stecker";
    }
}

