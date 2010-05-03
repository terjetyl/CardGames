using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGames
{
    public class Hand
    {
        /// <summary>
        /// The cards in the hand.
        /// </summary>
        private List<Card> cards = new List<Card>();
        public List<Card> Cards
        {
            get { return cards; }
        }

        /// <summary>
        /// Creates a new empty hand.
        /// </summary>
        public Hand()
        {
            
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
            cards.Add(card);
            OnHandChanged(EventArgs.Empty);
        }

        /// <summary>
        /// The number of cards currently in the hand.
        /// </summary>
        public int CardCount
        {
            get { return cards.Count; }
        }

        /// <summary>
        /// The total value of the hand, based on the most common card values (J, Q, K are all 10, A is 1).
        /// </summary>
        public int HandTotal
        {
            get
            {
                int total = 0;
                foreach (Card card in cards)
                {
                    total += (int)card.Rank;
                }
                return total;
            }
        }
    }
}
