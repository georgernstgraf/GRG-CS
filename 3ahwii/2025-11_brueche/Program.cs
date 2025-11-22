namespace _2025_11_brueche;

internal static class Program
{
    internal static void Main(string[] args)
    {
        Console.WriteLine("Hello, World als Klasse!");
        foreach (var s in args) Console.WriteLine(s);

        var b1 = new Bruch(args[0]);
        var b2 = new Bruch(args[1]);
        var b3 = b1.Addiere(b2);
        Console.WriteLine("Ergebnis: " + b3);
    }
}