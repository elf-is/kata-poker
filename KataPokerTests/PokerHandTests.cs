using KataPoker;

namespace KataPokerTests;

public class Tests
{
    private readonly PokerHand _handWithAPair = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private readonly PokerHand _handWithHighCard = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ten),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private readonly PokerHand _handWithThreeOfAKind = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private readonly PokerHand _handWithFourOfAKind = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Ace),
        new Card(color: Color.Spade, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private readonly PokerHand _handWithTwoPairs = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Two),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private readonly PokerHand _handWithFullHouse = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Two)
    ]);

    private readonly PokerHand _handWithSimpleFlush = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Club, rank: Rank.Two),
        new Card(color: Color.Club, rank: Rank.Eight),
        new Card(color: Color.Club, rank: Rank.Five),
        new Card(color: Color.Club, rank: Rank.Four)
    ]);

    private readonly PokerHand _handWithStraight = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Five),
        new Card(color: Color.Club, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Two),
        new Card(color: Color.Club, rank: Rank.Four)
    ]);

    private readonly PokerHand _handWithPseudoStraight = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Five),
        new Card(color: Color.Club, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Three),
        new Card(color: Color.Club, rank: Rank.Four)
    ]);

    private readonly PokerHand _handWithStraightFlush = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Club, rank: Rank.Five),
        new Card(color: Color.Club, rank: Rank.Three),
        new Card(color: Color.Club, rank: Rank.Two),
        new Card(color: Color.Club, rank: Rank.Four)
    ]);

    private readonly PokerHand _handWithStraigthEndingWithAce = new([
        new Card(color: Color.Club, rank: Rank.Ten),
        new Card(color: Color.Heart, rank: Rank.Jack),
        new Card(color: Color.Club, rank: Rank.Queen),
        new Card(color: Color.Club, rank: Rank.King),
        new Card(color: Color.Club, rank: Rank.Ace)
    ]);

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenAHandWithAPairWhenCheckingForAPairThenReturnTrue()
    {
        bool result = _handWithAPair.HasAPair();
        Assert.IsTrue(result);
    }

    [Test]
    public void GivenAHandWithoutAPairWhenCheckingForAPairThenReturnFalse()
    {
        bool result = _handWithHighCard.HasAPair();
        Assert.IsFalse(result);
    }

    [Test]
    public void GivenAHandWithThreeOfAKindWhenCheckingForThreeOfAKindThenReturnTrue()
    {
        bool hasThreeOfAKind = _handWithThreeOfAKind.HasThreeOfAKind();

        Assert.IsTrue(hasThreeOfAKind);
    }

    [Test]
    public void GivenAHandWithAPairWhenCheckingForThreeOfAKindThenReturnFalse()
    {
        bool hasThreeOfAKind = _handWithAPair.HasThreeOfAKind();

        Assert.IsFalse(hasThreeOfAKind);
    }

    [Test]
    public void GivenAHandWithoutThreeOfAKindWhenCheckingForThreeOfAKindThenReturnFalse()
    {
        bool hasThreeOfAKind = _handWithHighCard.HasThreeOfAKind();

        Assert.IsFalse(hasThreeOfAKind);
    }
    [Test]
    public void GivenAHandWithFourOfAKindWhenCheckingForFourOfAKindThenReturnTrue()
    {
        bool hasFourOfAKind = _handWithFourOfAKind.HasFourOfAKind();

        Assert.IsTrue(hasFourOfAKind);
    }
    [Test]
    public void GivenAHandWithoutFourOfAKindWhenCheckingForFourOfAKindThenReturnFalse()
    {
        bool hasFourOfAKind = _handWithHighCard.HasFourOfAKind();

        Assert.IsFalse(hasFourOfAKind);
    }

    [Test]
    public void GivenAHandWithTwoPairWhenCheckingForTwoPairThenReturnTrue()
    {
        bool hasTwoPair = _handWithTwoPairs.HasTwoPairs();
        Assert.IsTrue(hasTwoPair);
    }

    [Test]
    public void GivenAHandWithoutTwoPairWhenCheckingForTwoPairThenReturnFalse()
    {
        bool hasTwoPair = _handWithHighCard.HasTwoPairs();
        Assert.IsFalse(hasTwoPair);
    }

    [Test]
    public void GivenAHandWithTwoPairWhenCheckingForAPairThenReturnFalse()
    {
        bool hasAPair = _handWithTwoPairs.HasAPair();
        Assert.IsFalse(hasAPair);
    }

    [Test]
    public void GivenAHandWithThreeOfAKindAndAPairWhenCheckingForAFullHouseReturnTrue()
    {
        bool hasAFullHouse = _handWithFullHouse.HasFullHouse();
        Assert.IsTrue(hasAFullHouse);
    }
    [Test]
    public void GivenAHandWithHighHandWhenCheckingForAFullHouseReturnFalse()
    {
        bool hasAFullHouse = _handWithHighCard.HasFullHouse();
        Assert.IsFalse(hasAFullHouse);
    }
    [Test]
    public void GivenAHandWithSimpleFlushWhenCheckingForASimpleFlushReturnTrue()
    {
        bool hasASimpleFlush = _handWithSimpleFlush.HasASimpleFlush();
        Assert.IsTrue(hasASimpleFlush);
    }
    [Test]
    public void GivenAHandWithoutSimpleFlushWhenCheckingForASimpleFlushReturnFalse()
    {
        bool hasASimpleFlush = _handWithHighCard.HasASimpleFlush();
        Assert.IsFalse(hasASimpleFlush);
    }
    [Test]
    public void GivenAHandWithAStraightWhenCheckingForAStraightReturnTrue()
    {
        bool hasAStraight = _handWithStraight.HasSimpleStraight();
        Assert.IsTrue(hasAStraight);
    }
    [Test]
    public void GivenAHandWithoutAStraightWhenCheckingForAStraightReturnFalse()
    {
        bool hasAStraight = _handWithHighCard.HasSimpleStraight();
        Assert.IsFalse(hasAStraight);
    }
    [Test]
    public void GivenAHandWithPseudoStraightWhenCheckingForStraightReturnFalse()
    {
        bool hasAStraight = _handWithPseudoStraight.HasSimpleStraight();
        Assert.IsFalse(hasAStraight);
    }

    [Test]
    public void GivenAHandWithAStraightFlushWhenCheckingForAStraightReturnFalse()
    {
        bool hasAStraight = _handWithStraightFlush.HasSimpleStraight();
        Assert.IsFalse(hasAStraight);
    }

    [Test]
    public void GivenAHandWithAStraightEndedWithAceWhenCheckingForAStraightReturnTrue()
    {
        bool hasAStraight = _handWithStraigthEndingWithAce.HasSimpleStraight();
        Assert.IsTrue(hasAStraight);
    }
}
