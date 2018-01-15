namespace Wonders.Cards
{
    public interface IBuildingCard
    {
        int Wood { get; set; }
        int Stone { get; set; }
        int Gold { get; set; }
        int Brick { get; set; }
        int Papirus { get; set; }
        int Glass { get; set; }
        int Cloth { get; set; }
    }
}