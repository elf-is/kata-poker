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
    => list.Max() - list.Min() == 4;

    private bool IsDistinctRank() => Cards.DistinctBy(r => r.Rank).Count() == 5;

    public bool HasStraightFlush()
    => HasASimpleFlush() && HasStraight();

    public bool HasRoyalFLush()
    => HasStraightFlush() && HasAce() && HasKing();
    
    public bool HasHighCard() => !HasAPair() &&
                                 !HasTwoPairs() &&
                                 !HasThreeOfAKind() &&
                                 !HasFourOfAKind() &&
                                 !HasStraightFlush() &&
                                 !HasASimpleFlush() &&
                                 !HasStraight() &&
                                 !HasRoyalFLush();
    
    private bool HasAce() => Cards.Exists(r => r.Rank == Rank.Ace);
    
    private bool HasKing() => Cards.Exists(r => r.Rank == Rank.King);
}