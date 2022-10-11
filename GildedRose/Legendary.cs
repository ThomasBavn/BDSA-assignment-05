namespace GildedRose;


public class Legendary : Item
{
    private int _quality;
    public override int Quality
    {
        get { return _quality; }
        set
        {
            _quality = value;
        }
    }

    public override void Update()
    {
        // should be empty
    }
}