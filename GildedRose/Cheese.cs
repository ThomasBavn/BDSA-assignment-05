namespace GildedRose;


public class Cheese : Item
{
  public override void Update() {

    if (Quality < 50) {
      Quality++;
    }
    SellIn--;


    if (SellIn < 0 && Quality < 50) {
      Quality++;
    }

  }
}