namespace GildedRose.Tests;

public class ProgramTests
{
    IList < Item > Items;
    Program p;

    public ProgramTests() {
      p = new Program();
      Items = new List<Item>();
    }
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }
}