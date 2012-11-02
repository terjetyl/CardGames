using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    public class Hand
    {
        /// <summary>
        /// The cards in the hand.
        /// </summary>
        private readonly List<Card> _cards = new List<Card>();
        public List<Card> Cards
        {
            get { return _cards; }
        }

        private readonly Player _player;

        /// <summary>
        /// Creates a new empty hand.
        /// </summary>
        public Hand(Player player)
        {
            _player = player;
        }

        public event HandChangedEventHandler HandChanged;
        protected void OnHandChanged(EventArgs e)
        {
            if (HandChanged != null)
            {
                HandChanged(this, e);
            }
        }

        /// <summary>
        /// Adds a card to a hand.
        /// </summary>
        /// <param name="card">The Card object to add to the hand.</param>
        public void AddCard(Card card)
        {
            _cards.Add(card);
            OnHandChanged(EventArgs.Empty);
        }

        /// <summary>
        /// The number of cards currently in the hand.
        /// </summary>
        public int CardCount
        {
            get { return _cards.Count; }
        }

        /// <summary>
        /// The total value of the hand, based on the most common card values (J, Q, K are all 10, A is 1).
        /// </summary>
        public int HandTotal
        {
            get
            {
                int total = 0;
                foreach (Card card in _cards)
                {
                    total += (int)card.Rank;
                }
                return total;
            }
        }

        public Card PlayCard(int index)
        {
            var card = Cards[index];
            Cards.Remove(card);
            return card;
        }

        public Player Player { get { return _player; } }

        public Card GetCardByShortName(string shortName)
        {
            return Cards.SingleOrDefault(o => o.ShortName == shortName);
        }

        public Card PlayCard(string shortName)
        {
            var card = Cards.SingleOrDefault(o => o.ShortName == shortName);
            if (card == null)
                return null;
            Cards.Remove(card);
            return card;
        }
    }
}
