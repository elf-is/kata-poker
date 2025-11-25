namespace KataPoker;

public class PokerHand(List<Card> cards)
{
    private List<Card> Cards { get; } = cards;

    public bool HasAPair() => CheckForAGroup(2);

    public bool HasThreeOfAKind() => CheckForAGroup(3);

    private bool CheckForAGroup(int groupSize)
        => Cards.GroupBy(card => card.Rank)
                .Count(group => group.Count() == groupSize) ==
           1;
    public bool HasFourOfAKind() => CheckForAGroup(4);
    public bool HasTwoPairs()
        => Cards.GroupBy(card => card.Rank)
                .Count(group => group.Count() == 2) ==
           2;
    public bool HasFullHouse()
        => HasAPair() && HasThreeOfAKind();
    public bool HasASimpleFlush()
        => Cards.GroupBy(g => g.Color).Any(g => g.Count() == 5);
    public bool HasSimpleStraight()
        => HasStraight()
            && !HasASimpleFlush();
    private bool HasStraight()
        => Cards.GroupBy(r => r.Rank).Count(r => r.Count() == 1) == 5
           && GetMaxValue() - GetMinValue() == 4;

    private int GetMaxValue()
    {
        if (Cards.Exists(card => card.Rank == Rank.King) && Cards.Exists(card => card.Rank == Rank.Ace))
            return (int)Rank.King + 1;
        return (int)Cards.Max(r => r.Rank);
    }

    private int GetMinValue()
    {
        if (Cards.Exists(card => card.Rank == Rank.King) && Cards.Exists(card => card.Rank == Rank.Ace))
            return (int)Rank.Ten;
        return (int)Cards.Min(r => r.Rank);
    }
}
