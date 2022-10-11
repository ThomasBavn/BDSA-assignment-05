using System;
using System.Collections.Generic;
namespace GildedRose;

public class Program
{
    public IList<Item> Items;
    static void Main(string[] args)
    {
        //   System.Console.WriteLine("OMGHAI!");

        //   var app = new Program() {
        //     Items = new List < Item > {
        //       new Item {
        //         Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20
        //       },
        //       new Item {
        //         Name = "Aged Brie", SellIn = 2, Quality = 0
        //       },
        //       new Item {
        //         Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7
        //       },
        //       new Item {
        //         Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80
        //       },
        //       new Item {
        //         Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80
        //       },
        //       new Item {
        //         Name = "Backstage passes to a TAFKAL80ETC concert",
        //           SellIn = 15,
        //           Quality = 20
        //       },
        //       new Item {
        //         Name = "Backstage passes to a TAFKAL80ETC concert",
        //           SellIn = 10,
        //           Quality = 49
        //       },
        //       new Item {
        //         Name = "Backstage passes to a TAFKAL80ETC concert",
        //           SellIn = 5,
        //           Quality = 49
        //       },
        //       // this conjured item does not work properly yet
        //       new Item {
        //         Name = "Conjured Mana Cake", SellIn = 3, Quality = 6
        //       }
        //     }

        //   };

        //   for (var i = 0; i < 31; i++) {
        //     Console.WriteLine("-------- day " + i + " --------");
        //     Console.WriteLine("name, sellIn, quality");
        //     for (var j = 0; j < app.Items.Count; j++) {
        //       Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
        //     }
        //     Console.WriteLine("");
        //     app.UpdateQuality();
        //   }

    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros") continue;
            item.SellIn--;
            switch (item.Name)
            {
                case "Aged Brie":
                    if (item.Quality == 50) continue;
                    item.Quality++;
                    if (item.SellIn < 0)
                        item.Quality++;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                        break;
                    }
                    if (item.Quality < 50)
                        item.Quality++;
                    if (item.SellIn <= 10 && item.Quality < 50)
                        item.Quality++;
                    if (item.SellIn <= 5 && item.Quality < 50)
                        item.Quality++;
                    break;
                default:
                    if (item.Quality == 0) continue;
                    item.Quality--;
                    if (item.SellIn < 0 && item.Quality != 0)
                        item.Quality--;
                    break;
            }




            // if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            // {
            //     if (item.Quality > 0)
            //     {
            //         if (item.Name != "Sulfuras, Hand of Ragnaros")
            //         {
            //             item.Quality = item.Quality - 1;
            //         }
            //     }
            // }
            // else
            // {
            //     if (item.Quality < 50)
            //     {
            //         item.Quality = item.Quality + 1;

            //         if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            //         {
            //             if (item.SellIn < 11)
            //             {
            //                 if (item.Quality < 50)
            //                 {
            //                     item.Quality = item.Quality + 1;
            //                 }
            //             }

            //             if (item.SellIn < 6)
            //             {
            //                 if (item.Quality < 50)
            //                 {
            //                     item.Quality = item.Quality + 1;
            //                 }
            //             }
            //         }
            //     }
            // }

            // if (item.Name != "Sulfuras, Hand of Ragnaros")
            // {
            //     item.SellIn = item.SellIn - 1;
            // }

            // if (item.SellIn < 0)
            // {
            //     if (item.Name != "Aged Brie")
            //     {
            //         if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            //         {
            //             if (item.Quality > 0)
            //             {
            //                 if (item.Name != "Sulfuras, Hand of Ragnaros")
            //                 {
            //                     item.Quality = item.Quality - 1;
            //                 }
            //             }
            //         }
            //         else
            //         {
            //             item.Quality = item.Quality - item.Quality;
            //         }
            //     }
            //     else
            //     {
            //         if (item.Quality < 50)
            //         {
            //             item.Quality = item.Quality + 1;
            //         }
            //     }
            // }
        }
    }

}

public class Item
{
    public string Name
    {
        get;
        set;
    }

    public int SellIn
    {
        get;
        set;
    }

    public int Quality
    {
        get;
        set;
    }
}

