namespace GildedRose.Tests;

public class ProgramTests
{
    Program _program;
    IList<Item> _items;

    public ProgramTests()
    {
        _program = new Program();
        _program.Items = new List<Item>();
        _items = _program.Items;
    }

    [Fact]
    public void aged_brie_increases_quality_as_days_pass() 
    {
      _items.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });

      Item cheese = _items[0];

      Assert.Equal(0, cheese.Quality);

      _program.UpdateQuality();

      Assert.Equal(1, cheese.Quality);
    }

}