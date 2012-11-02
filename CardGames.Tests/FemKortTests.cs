using System.Linq;
using CardGames.Games;
using Xunit;

namespace CardGames.Tests
{
    public class FemKortTests
    {
        [Fact]
        public void SetupTest()
        {
            var game = new FemKort(new Player("1"), new Player("2"));

            game.ShuffleAndDeal();

            Assert.Equal(42, game.Deck.Cards.Count());

            Assert.Equal(5, game.Hand1.CardCount);
            Assert.Equal(5, game.Hand2.CardCount);
        }

        [Fact]
        public void PlayRoundTest()
        {
            var game = new FemKort(new Player("1"), new Player("2"));
            game.ShuffleAndDeal();

            game.PlayRound(game.Hand1.Player, game.Hand1.PlayCard(0));
            game.PlayRound(game.Hand2.Player, game.Hand2.PlayCard(0));

            Assert.Equal(1, game.Rounds.Count());
            Assert.True(game.Rounds.First().GetWinner() != null);
        }
    }
}
