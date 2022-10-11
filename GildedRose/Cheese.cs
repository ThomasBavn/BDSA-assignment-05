namespace GildedRose;


public class Cheese : Item
{
  public override void Update() {
    SellIn--;
    Quality++;
    if (SellIn < 0) Quality++;
  }
}