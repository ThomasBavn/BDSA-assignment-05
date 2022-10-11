namespace GildedRose;


public class Ticket : Item
{
    public override void Update()
    {
        Quality++;
        if (SellIn < 11) Quality++;
        if (SellIn < 6) Quality++;
        SellIn--;
        if (SellIn < 0) Quality = 0;
    }
}