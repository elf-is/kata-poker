namespace KataPoker;

public record Card
{
    public Card()
    {
    }
    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }
    public Rank Rank { get; set; }
    public Color Color { get; set; }
}
