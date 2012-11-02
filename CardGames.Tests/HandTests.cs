using Xunit;

namespace CardGames.Tests
{
    public class HandTests
    {
        [Fact]
        public void PlayCardTest()
        {
            var hand = new Hand(new Player("yes"));
            var card = new Card(Rank.Ace, Suit.Clubs);
            hand.AddCard(card);

            var card2 = hand.PlayCard("3c");
            Assert.Null(card2);
            Assert.Equal(1, hand.CardCount);

            var card3 = hand.PlayCard(card.ShortName);
            Assert.NotNull(card3);
            Assert.Equal(0, hand.CardCount);
        }
    }
}
