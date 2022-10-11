namespace GildedRose;


public class Item
{
    private int _quality;
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

    public virtual int Quality
    {
        get { return _quality; }
        set {
          if(value > 50) _quality = 50;
          else if(value < 0) _quality = 0;
          else _quality = value;
        }
    }

    public virtual void Update() {
      SellIn--;
      Quality -= (SellIn < 0) ? 2 : 1;
    }
}