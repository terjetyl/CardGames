using System.Linq;
using Xunit;

namespace CardGames.Tests
{
    public class DeckTests
    {
        [Fact]
        public void SetupTest()
        {
            var deck = new Deck();
            Assert.Equal(52, deck.Cards.Count);
            Assert.Equal(0, deck.Cards.FindDuplicates().Count());
        }

        [Fact]
        public void DealTest()
        {
            var deck = new Deck();
            var card = deck.DealCard();
            Assert.NotNull(card);
            Assert.Equal(51, deck.Cards.Count);
            Assert.False(deck.Cards.Any(o => o.Rank == card.Rank && o.Suit == card.Suit));
        }
    }
}
