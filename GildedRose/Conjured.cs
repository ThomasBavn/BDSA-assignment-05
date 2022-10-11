namespace GildedRose;


public class Conjured : Item
{
    public override void Update()
    {
        SellIn--;
        Quality -= (SellIn < 0) ? 4 : 2;
    }
}