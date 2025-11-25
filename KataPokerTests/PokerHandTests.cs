using KataPoker;

namespace KataPokerTests;

public class Tests
{
    private static readonly PokerHand HandWithAPair = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private static readonly PokerHand HandWithHighCard = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ten),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private static readonly PokerHand HandWithThreeOfAKind = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Three),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private static readonly PokerHand HandWithFourOfAKind = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Ace),
        new Card(color: Color.Spade, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private static readonly PokerHand HandWithTwoPairs = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Two),
        new Card(color: Color.Spade, rank: Rank.Five)
    ]);

    private static readonly PokerHand HandWithFullHouse = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Diamond, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Ace),
        new Card(color: Color.Heart, rank: Rank.Two),
        new Card(color: Color.Diamond, rank: Rank.Two)
    ]);

    private static readonly PokerHand HandWithSimpleFlush = new([
        new Card(color: Color.Club, rank: Rank.Ace),
        new Card(color: Color.Club, rank: Rank.Two),
        new Card(color: Color.Club, rank: Rank.Eight),
        new Card(color: Color.Club, rank: Rank.Five),
        new Card(color: Color.Club, rank: Rank.Four)
    ]);

    private static readonly PokerHand HandWithStraight = new([
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

    private static readonly PokerHand HandWithStraightFlush = new([
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
    
    private readonly PokerHand _handWithAKindOfStraigthEndingWithtAce = new([
        new Card(color: Color.Club, rank: Rank.Nine),
        new Card(color: Color.Heart, rank: Rank.Jack),
        new Card(color: Color.Club, rank: Rank.Queen),
        new Card(color: Color.Club, rank: Rank.King),
        new Card(color: Color.Club, rank: Rank.Ace)
    ]);
    
    private static readonly PokerHand HandWithARoyalFlush = new([
        new Card(color: Color.Club, rank: Rank.Ten),
        new Card(color: Color.Club, rank: Rank.Jack),
        new Card(color: Color.Club, rank: Rank.Queen),
        new Card(color: Color.Club, rank: Rank.King),
        new Card(color: Color.Club, rank: Rank.Ace)
    ]);
    
    [DatapointSource]
    private PokerHand[] _hand= [HandWithAPair,
        HandWithThreeOfAKind,
        HandWithFourOfAKind,
        HandWithTwoPairs,
        HandWithFullHouse,
        HandWithSimpleFlush,
        HandWithStraight,
        HandWithStraightFlush,
        HandWithARoyalFlush];

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenAHandWithAPairWhenCheckingForAPairThenReturnTrue()
    {
        bool result = HandWithAPair.HasAPair();
        Assert.IsTrue(result);
    }

    [Test]
    public void GivenAHandWithoutAPairWhenCheckingForAPairThenReturnFalse()
    {
        bool result = HandWithHighCard.HasAPair();
        Assert.IsFalse(result);
    }

    [Test]
    public void GivenAHandWithThreeOfAKindWhenCheckingForThreeOfAKindThenReturnTrue()
    {
        bool hasThreeOfAKind = HandWithThreeOfAKind.HasThreeOfAKind();

        Assert.IsTrue(hasThreeOfAKind);
    }

    [Test]
    public void GivenAHandWithAPairWhenCheckingForThreeOfAKindThenReturnFalse()
    {
        bool hasThreeOfAKind = HandWithAPair.HasThreeOfAKind();

        Assert.IsFalse(hasThreeOfAKind);
    }

    [Test]
    public void GivenAHandWithoutThreeOfAKindWhenCheckingForThreeOfAKindThenReturnFalse()
    {
        bool hasThreeOfAKind = HandWithHighCard.HasThreeOfAKind();

        Assert.IsFalse(hasThreeOfAKind);
    }

    [Test]
    public void GivenAHandWithFourOfAKindWhenCheckingForFourOfAKindThenReturnTrue()
    {
        bool hasFourOfAKind = HandWithFourOfAKind.HasFourOfAKind();

        Assert.IsTrue(hasFourOfAKind);
    }

    [Test]
    public void GivenAHandWithoutFourOfAKindWhenCheckingForFourOfAKindThenReturnFalse()
    {
        bool hasFourOfAKind = HandWithHighCard.HasFourOfAKind();

        Assert.IsFalse(hasFourOfAKind);
    }

    [Test]
    public void GivenAHandWithTwoPairWhenCheckingForTwoPairThenReturnTrue()
    {
        bool hasTwoPair = HandWithTwoPairs.HasTwoPairs();
        Assert.IsTrue(hasTwoPair);
    }

    [Test]
    public void GivenAHandWithoutTwoPairWhenCheckingForTwoPairThenReturnFalse()
    {
        bool hasTwoPair = HandWithHighCard.HasTwoPairs();
        Assert.IsFalse(hasTwoPair);
    }

    [Test]
    public void GivenAHandWithTwoPairWhenCheckingForAPairThenReturnFalse()
    {
        bool hasAPair = HandWithTwoPairs.HasAPair();
        Assert.IsFalse(hasAPair);
    }

    [Test]
    public void GivenAHandWithThreeOfAKindAndAPairWhenCheckingForAFullHouseReturnTrue()
    {
        bool hasAFullHouse = HandWithFullHouse.HasFullHouse();
        Assert.IsTrue(hasAFullHouse);
    }

    [Test]
    public void GivenAHandWithHighHandWhenCheckingForAFullHouseReturnFalse()
    {
        bool hasAFullHouse = HandWithHighCard.HasFullHouse();
        Assert.IsFalse(hasAFullHouse);
    }

    [Test]
    public void GivenAHandWithSimpleFlushWhenCheckingForASimpleFlushReturnTrue()
    {
        bool hasASimpleFlush = HandWithSimpleFlush.HasASimpleFlush();
        Assert.IsTrue(hasASimpleFlush);
    }

    [Test]
    public void GivenAHandWithoutSimpleFlushWhenCheckingForASimpleFlushReturnFalse()
    {
        bool hasASimpleFlush = HandWithHighCard.HasASimpleFlush();
        Assert.IsFalse(hasASimpleFlush);
    }

    [Test]
    public void GivenAHandWithAStraightWhenCheckingForAStraightReturnTrue()
    {
        bool hasAStraight = HandWithStraight.HasSimpleStraight();
        Assert.IsTrue(hasAStraight);
    }

    [Test]
    public void GivenAHandWithoutAStraightWhenCheckingForAStraightReturnFalse()
    {
        bool hasAStraight = HandWithHighCard.HasSimpleStraight();
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
        bool hasAStraight = HandWithStraightFlush.HasSimpleStraight();
        Assert.IsFalse(hasAStraight);
    }

    [Test]
    public void GivenAHandWithAStraightEndedWithAceWhenCheckingForAStraightReturnTrue()
    {
        bool hasAStraight = _handWithStraigthEndingWithAce.HasSimpleStraight();
        Assert.IsTrue(hasAStraight);
    }
    
    [Test]
    public void GivenAHandWithAKindOfStraightEndedWithAceWhenCheckingForAStraightReturnFalse()
    {
        bool hasAStraight = _handWithAKindOfStraigthEndingWithtAce.HasSimpleStraight();
        Assert.IsFalse(hasAStraight);
    }

    [Test]
    public void GiventAHandWithStaightFlushWhenCheckingForAStraightFlushReturnTrue()
    {
        bool hasStraightFlush = HandWithStraightFlush.HasStraightFlush();
        Assert.IsTrue(hasStraightFlush);
    }
    
    [Test]
    public void GiventAHandWithStraightWhenCheckingForAStraightFlushReturnFalse()
    {
        bool hasStraightFlush = HandWithStraight.HasStraightFlush();
        Assert.IsFalse(hasStraightFlush);
    }
    
    [Test]
    public void GiventAHandWithARoyalFlushWhenCheckingForARoyalFlushReturnTrue()
    {
        bool hasRoyalFLush = HandWithARoyalFlush.HasRoyalFLush();
        Assert.IsTrue(hasRoyalFLush);
    }
    [Test]
    public void GiventAHandWithoutARoyalFlushWhenCheckingForARoyalFlushReturnFalse()
    {
        bool hasRoyalFLush = HandWithStraight.HasRoyalFLush();
        Assert.IsFalse(hasRoyalFLush);
    }

    [Test]
    public void GivenAhandWithHighCardWhenCheckingForHighCardReturnTrue()
    {
        bool hasHighCard = HandWithHighCard.HasHighCard();
        Assert.IsTrue(hasHighCard);
    }
    
    [Theory]
    public void GivenAHandWithAPairWhenCheckingForHighCardReturnFalse(PokerHand hand)
    {
        bool hasHighCard = hand.HasHighCard();
        Assert.IsFalse(hasHighCard);
    }
}