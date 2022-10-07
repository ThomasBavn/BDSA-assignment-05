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