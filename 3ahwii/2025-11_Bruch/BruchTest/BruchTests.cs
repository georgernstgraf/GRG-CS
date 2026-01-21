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

    [Theory]
    [InlineData("3 7/11", "3 7/11")]           // already normalized
    [InlineData("0 15/10", "1 1/2")]           // normalize and reduce
    [InlineData("2 3/4", "2 3/4")]             // unchanged
    [InlineData("1 2/2", "2")]             // becomes whole number with 0/1 remainder
    public void ToString_Normalizes_And_Formats_For_Multiple_Inputs(string input, string expected)
    {
        var b = new Bruch(input);
        Assert.Equal(expected, b.ToString());
    }

    [Fact]
    public void Constructor_Throws_Exception_On_Zero_Denominator()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Bruch("1 1/0"));
        Assert.Equal("Der Nenner darf nicht Null sein.", ex.Message);
    }
}
