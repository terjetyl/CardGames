using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    public class Round
    {
        private readonly int _playerCount;

        public Round(int playerCount)
        {
            _playerCount = playerCount;
        }

        private readonly List<Tuple<Player, Card>> _cards = new List<Tuple<Player, Card>>();

        public Player GetWinner()
        {
            if (_cards.Count != _playerCount)
                return null;

            var winnerCard = _cards.First();
            foreach (var tuple in _cards)
            {
                if (tuple.Item2.Suit == winnerCard.Item2.Suit && tuple.Item2.Rank > winnerCard.Item2.Rank)
                    winnerCard = tuple;
            }
            return winnerCard.Item1;
        }

        public void Add(Player player, Card card)
        {
            _cards.Add(new Tuple<Player, Card>(player, card));
        }

    }
}