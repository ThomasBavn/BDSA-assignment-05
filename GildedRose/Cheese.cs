namespace GildedRose;


public class Cheese : Item
{
    public override void Update()
    {
        SellIn--;
        Quality += SellIn < 0 ? 2 : 1;
    }
}