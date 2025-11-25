namespace KataPoker;

public class PokerHand(List<Card> cards)
{
    private List<Card> Cards { get; } = cards;

    public bool HasAPair() => CheckForAGroup(2);

    public bool HasThreeOfAKind() => CheckForAGroup(3);

    private bool CheckForAGroup(int groupSize, int groupOccurences = 1)
        => Cards.GroupBy(card => card.Rank)
               .Count(group => group.Count() == groupSize) ==
           groupOccurences;

    public bool HasFourOfAKind() => CheckForAGroup(4);

    public bool HasTwoPairs()
        => CheckForAGroup(2, 2);

    public bool HasFullHouse()
        => HasAPair() && HasThreeOfAKind();

    public bool HasASimpleFlush()
        => Cards.GroupBy(g => g.Color).Any(g => g.Count() == 5);

    public bool HasSimpleStraight()
        => HasStraight() && !HasASimpleFlush();

    private bool HasStraight()
    {
        var first = Cards.Select(card => (int)card.Rank).Order().ToList();
        var second = first.Select(cardValue => cardValue == 1 ? (int)Rank.King + 1 : cardValue).Order().ToList();
        
        return IsDistinctRank() && (CalculateRankRange(first) || CalculateRankRange(second));
    }

    private static bool CalculateRankRange(List<int> list)
    {
        return list.Max() - list.Min() == 4;
    }

    private bool IsDistinctRank() => Cards.DistinctBy(r => r.Rank).Count() == 5;

    private int GetMaxValue()
    {
        if (Cards.Exists(card => card.Rank == Rank.King) && Cards.Exists(card => card.Rank == Rank.Ace))
            return (int)Rank.King + 1;
        return (int)Cards.Max(r => r.Rank);
    }

    private int GetMinValue()
    {
        var cards = Cards;
        if (Cards.Exists(card => card.Rank == Rank.King) && Cards.Exists(card => card.Rank == Rank.Ace))
            cards = Cards.Where(card => card.Rank != Rank.Ace).ToList();
        return (int)cards.Min(r => r.Rank);
    }
}