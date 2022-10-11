namespace GildedRose;


public class Ticket : Item
{
  public override void Update() {

    if (Quality < 50) {
      Quality++;
      if (SellIn < 11) {
        if (Quality < 50) {
            Quality++;
        }
      }
      if (SellIn < 6) {
        if (Quality < 50) {
            Quality++;
        }
      }
    }

    SellIn--;

    if (SellIn < 0) {
      Quality = Quality - Quality;
    }

  }
}