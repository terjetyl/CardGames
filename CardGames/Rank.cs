namespace CardGames
{
    // Problem: in this enum, the underlying value of each constant is also the Rank's value in blackjack.
    // This makes this code less re-usable, as the ranks may have different values in the context of other games.



    /// <summary>
    /// The rank of a card.
    /// </summary>
    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 10,
        Queen = 10,
        King = 10
    }
}