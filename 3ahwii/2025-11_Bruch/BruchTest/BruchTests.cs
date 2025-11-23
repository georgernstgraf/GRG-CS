using BruchName;

namespace BruchTest;

public class BruchTests
{
    [Fact]
    public void Constructor_Parses_Mixed_Number()
    {
        var b = new Bruch("3 7/11");
        Assert.Equal("3 7/11", b.ToString());
    }

    [Fact]
    public void ToString_Formats_Kuerzt_And_Normalizes()
    {
        // 0 15/10 -> 1 1/2 after normalize/kuerzen
        var b = new Bruch("0 15/10");
        Assert.Equal("1 1/2", b.ToString());
    }

    [Fact]
    public void Addiere_Returns_Correct_Sum()
    {
        // 1 1/2 + 2 1/3 = 3 + 5/6 = 3 5/6
        var a = new Bruch("1 1/2");
        var c = new Bruch("2 1/3");
        var sum = a.Addiere(c);
        Assert.Equal("3 5/6", sum.ToString());
    }
}
