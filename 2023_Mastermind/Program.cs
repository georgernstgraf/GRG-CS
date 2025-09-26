class Program
{
    public static void Main(string[] args)
    {
        macheVersuche();
    }

    public static void macheVersuche ()
    {
        Farbcode vorgabe = new Farbcode(new Farbe[] { Farbe.Blau, Farbe.Rot, Farbe.Braun, Farbe.Lila });
        Farbcode versuch1 = Farbcode.getRandom();
        Farbcode versuch2 = Farbcode.getRandom();
        Farbcode versuch3 = Farbcode.getRandom();
        Farbcode versuch4 = Farbcode.getRandom();
        Farbcode versuch5 = Farbcode.getRandom();
        Console.WriteLine($"Vorgabe:{vorgabe}");
        Bewertung bew1 = new Bewertung(vorgabe, versuch1);
        Bewertung bew2 = new Bewertung(vorgabe, versuch2);
        Bewertung bew3 = new Bewertung(vorgabe, versuch3);
        Bewertung bew4 = new Bewertung(vorgabe, versuch4);
        Bewertung bew5 = new Bewertung(vorgabe, versuch5);
        Console.WriteLine(bew1);
        Console.WriteLine(bew2);
        Console.WriteLine(bew3);
        Console.WriteLine(bew4);
        Console.WriteLine(bew5);
    }
}