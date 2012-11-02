using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Games
{
    public class FemKort
    {
        private readonly Deck _deck = new Deck();
        private readonly Hand _hand1;
        private readonly Hand _hand2;
        private Hand _currentHand;
        private readonly List<Round> _rounds = new List<Round>();
        private Round _currentRound = new Round(2);
        private const int PlayerCount = 2;
        private const int RoundCount = 5;

        private readonly Player _player1;
        private readonly Player _player2;

        public FemKort(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;

            _hand1 = new Hand(_player1);
            _hand2 = new Hand(_player2);

            _currentHand = _hand1;
        }

        public void ShuffleAndDeal()
        {
            _deck.Shuffle();

            for (int i = 0; i < RoundCount; i++)
            {
                DealToHand(_hand1);
                DealToHand(_hand2);
            }
        }

        public void PlayRound(Player player, Card card)
        {
            _currentRound.Add(player, card);
            _currentHand = player.Name == _hand1.Player.Name ? _hand2 : _hand1;
                
            if (_currentRound.GetWinner() != null)
            {
                _currentHand = _currentRound.GetWinner().Name == _hand1.Player.Name ? _hand1 : _hand2;
                _rounds.Add(_currentRound);
                _currentRound = new Round(PlayerCount);
            }
        }

        private void DealToHand(Hand hand)
        {
            var card = _deck.DealCard();
            hand.AddCard(card);
        }

        public Tuple<Player, int> GetWinner()
        {
            if (Rounds.Count() < RoundCount)
                return null;
            var winners = Rounds.Select(o => o.GetWinner());
            int player1Wins = winners.Count(o => o.Name == _player1.Name);
            int player2Wins = winners.Count(o => o.Name == _player2.Name);
            if(player1Wins > player2Wins)
                return new Tuple<Player, int>(_player1, player1Wins);
            return new Tuple<Player, int>(_player2, player2Wins);
        }

        public Hand Hand1 { get { return _hand1; } }
        public Hand Hand2 { get { return _hand2; } }
        public Deck Deck { get { return _deck; } }

        public IEnumerable<Round> Rounds { get { return _rounds; } }

        public Hand CurrentHand { get { return _currentHand; } }
    }
}
