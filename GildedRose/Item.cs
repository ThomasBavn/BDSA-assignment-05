namespace GildedRose;


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

    public virtual void Update() {
      if (Quality > 0) {
        Quality--;
      }

      SellIn--;

      if (SellIn < 0) {
        if (Quality > 0) {
          Quality--;
        }
      }
    }
}