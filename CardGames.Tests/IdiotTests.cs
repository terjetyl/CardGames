using System.Linq;
using Xunit;

namespace CardGames.Tests
{
    public class IdiotTests
    {
        [Fact]
        public void SetupTest()
        {
            var game = new Idiot();

            game.SetupGame();

            Assert.Equal(34, game.Deck.Cards.Count());

            Assert.Equal(9, game.Hand1.CardCount);
            Assert.Equal(9, game.Hand2.CardCount);
        }
    }

    class Idiot
    {
        private readonly Deck _deck = new Deck();
        private readonly Hand _hand1 = new Hand(new Player("1"));
        private readonly Hand _hand2 = new Hand(new Player("2"));

        public void SetupGame()
        {
            _deck.Shuffle();

            for (int i = 0; i < 3; i++)
            {
                DealToHand(_hand1, Visibility.Closed);
                DealToHand(_hand2, Visibility.Closed);
            }

            for (int i = 0; i < 3; i++)
            {
                DealToHand(_hand1, Visibility.Open);
                DealToHand(_hand2, Visibility.Open);
            }

            for (int i = 0; i < 3; i++)
            {
                DealToHand(_hand1, Visibility.Open);
                DealToHand(_hand2, Visibility.Open);
            }
        }

        public Hand Hand1 { get { return _hand1; } }
        public Hand Hand2 { get { return _hand2; } }
        public Deck Deck { get { return _deck; } }

        private void DealToHand(Hand hand, Visibility visibility)
        {
            var card = _deck.DealCard();
            card.Visibility = visibility;
            hand.AddCard(card);
        }
    }
}
