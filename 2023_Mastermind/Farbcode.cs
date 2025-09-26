class Farbcode
{
    private Farbe[] Stecker { get; }
    public Farbcode(Farbe[] plaetze)
    {
        if (plaetze == null || plaetze.Length != 4)
        {
            throw new ArgumentException("Es muß mit genau 4 Farben versucht werden"!);
        }
        Stecker = plaetze;
    }
    public override string ToString()
    {
        return $"| {Stecker[0],5} {Stecker[1],5} {Stecker[2],5} {Stecker[3],5} |";
    }

    public static Farbcode getRandom()
    {
        Farbe[] stecker = new Farbe[4];
        int idx;
        var rnd = new Random();
        for (int i = 0; i < 4; i++)
        {
            idx = rnd.Next(6);
            switch (idx)
            {
                case 0:
                    stecker[i] = Farbe.Rot;  break;
                case 1:
                    stecker[i] = Farbe.Gelb; break;
                case 2:
                    stecker[i] = Farbe.Grün; break;
                case 3:
                    stecker[i] = Farbe.Blau; break;
                case 4:
                    stecker[i] = Farbe.Lila; break;
                case 5:
                    stecker[i] = Farbe.Braun; break;
            }
        }
        return new Farbcode(stecker);
    }

}


