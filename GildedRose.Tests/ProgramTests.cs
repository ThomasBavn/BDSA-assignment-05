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
    public void aged_brie_increases_quality_as_days_pass() {
      _items.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
      Item cheese = _items[0];
      Assert.Equal(0, cheese.Quality);
      _program.UpdateQuality();
      Assert.Equal(1, cheese.Quality);
      _program.UpdateQuality();
    }

    [Fact]
    public void any_item_does_not_exceed_50_in_quality_as_days_pass() 
    {
      _items = new List < Item > {
        new Item {
          Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20
        },
        new Item {
          Name = "Aged Brie", SellIn = 2, Quality = 0
        },
        new Item {
          Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7
        },
        new Item {
          Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80
        },
        new Item {
          Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80
        },
        new Item {
          Name = "Backstage passes to a TAFKAL80ETC concert",
          SellIn = 15,
          Quality = 20
        },
        new Item {
          Name = "Backstage passes to a TAFKAL80ETC concert",
          SellIn = 10,
          Quality = 49
        },
        new Item {
          Name = "Backstage passes to a TAFKAL80ETC concert",
          SellIn = 5,
          Quality = 49
        },
        new Item {
          Name = "Conjured Mana Cake", SellIn = 3, Quality = 6
        }
      };

      for(int i = 0; i < 31; i++) {
        _program.UpdateQuality();
        foreach(Item item in _items) {
          bool below50 = item.Quality < 50;
          if(item.Name.Equals("Sulfuras, Hand of Ragnaros")) {
            Assert.False(below50);
          } else {
            Assert.True(below50);
          }
        }
      }
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

      [Fact]
    public void after_due_date_degrade_twice_as_fast()
    {
        //Arrange
        _items.Add(new Item { Name = "A new item", SellIn = -2, Quality = 10 });

        //Act
        _program.UpdateQuality();
        var updatedItem = _items[0];
        var expected = new Item { Name = "A new item", SellIn = -3, Quality = 8 };
        //Assert

        Assert.Equal(8,updatedItem.Quality);
    }



    [Fact]
    public void quality_never_under_zero()
    {
        //Arrange
        _items.Add(new Item { Name = "A new item", SellIn = -2, Quality = 1 });
        _items.Add(new Item { Name = "Another item", SellIn = 1, Quality = 0 });
        _items.Add(new Item { Name = "Third item", SellIn = -1, Quality = 2 });


        _program.UpdateQuality();
        var expected = new List<Item>(new[] {
            new Item { Name = "A new item", SellIn = -3, Quality = 0 },
            new Item { Name = "Another item", SellIn = 0, Quality = 0 },
            new Item { Name = "Third item", SellIn = -2, Quality = 0 }
        });

        for(int i = 0; i < expected.Count(); i++){
            Assert.Equal(expected[i].Quality,_items[i].Quality);
        }
    }

}