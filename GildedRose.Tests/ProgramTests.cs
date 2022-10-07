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

}