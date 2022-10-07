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

    [Fact]
    public void BackstagePasses_will_increase_by_1_when_more_than_10_days_left() 
    {
      _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 });

      Item concertInFifteen = _items[0];

      Assert.Equal(20, concertInFifteen.Quality);

      _program.UpdateQuality();

      Assert.Equal(23, concertInFifteen.Quality);

      _program.UpdateQuality();
      _program.UpdateQuality();
      _program.UpdateQuality();
      _program.UpdateQuality();

      Assert.Equal(35, concertInFifteen.Quality);

      _program.UpdateQuality();

      Assert.Equal(0, concertInFifteen.Quality);
    }

    [Fact]
    public void BackstagePasses_will_increase_by_2_when_there_is_less_than_ten_days_left() 
    {
      _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 });

      Item concertInTen = _items[0];

      Assert.Equal(20, concertInTen.Quality);

      _program.UpdateQuality();

      Assert.Equal(22, concertInTen.Quality);

      _program.UpdateQuality();
      _program.UpdateQuality();
      _program.UpdateQuality();
      _program.UpdateQuality();

      Assert.Equal(30, concertInTen.Quality);

      _program.UpdateQuality();

      Assert.Equal(33, concertInTen.Quality);
    }

    [Fact]
    public void BackstagePasses_will_increase_Quality_by_3_when_less_than_five_days_left_but_become_worthless_after_the_sellby_Becomes_less_than_zero() 
    {
      _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 });
      Item concertInFive = _items[0];
      
      Assert.Equal(20, concertInFive.Quality);

      _program.UpdateQuality();

      Assert.Equal(23, concertInFive.Quality);

      _program.UpdateQuality();
      _program.UpdateQuality();
      _program.UpdateQuality();
      _program.UpdateQuality();
      Assert.Equal(35, concertInFive.Quality);

      _program.UpdateQuality();
      Assert.Equal(0, concertInFive.Quality);
    }


}