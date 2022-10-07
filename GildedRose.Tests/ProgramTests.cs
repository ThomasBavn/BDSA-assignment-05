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
    public void Sulfuras_Will_NEVER_age() 
    {
      _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
      _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 });

      Item Sulfuras = _items[0];
      Item Sulfuras2ElectricBoogaloo = _items[1];

      Assert.Equal(0, Sulfuras.SellIn);
      Assert.Equal(-1, Sulfuras2ElectricBoogaloo.SellIn);

      _program.UpdateQuality();

      Assert.Equal(0, Sulfuras.SellIn);
      Assert.Equal(-1, Sulfuras2ElectricBoogaloo.SellIn);
    }

    [Fact]
    public void Sulfuras_Will_NEVER_degrade() 
    {
      _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
      _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 });

      Item Sulfuras = _items[0];
      Item Sulfuras2ElectricBoogaloo = _items[1];

      Assert.Equal(80, Sulfuras.Quality);
      Assert.Equal(80, Sulfuras2ElectricBoogaloo.Quality);

      _program.UpdateQuality();

      Assert.Equal(80, Sulfuras.Quality);
      Assert.Equal(80, Sulfuras2ElectricBoogaloo.Quality);
    }

}