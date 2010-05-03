using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CardGames
{
    /// <summary>
    /// A deck of cards.
    /// </summary>
    public class Deck
    {
        // A deck is a list of cards.
        private List<Card> cards = new List<Card>();

        /// <summary>
        /// Gets the list of cards in the deck.
        /// </summary>
        public List<Card> Cards
        {
            get { return cards; }
        }

        /// <summary>
        /// Creates a new deck with a default set of 52 cards.
        /// </summary>
        public Deck()
        {
            // Create every possible permutation of card by looping through all ranks and a nested loop of all suits
            foreach (String rank in Enum.GetNames(typeof(Rank)))
            {
                foreach (String suit in Enum.GetNames(typeof(Suit)))
                {
                    Card card = new Card((Rank)Enum.Parse(typeof(Rank), rank), (Suit)Enum.Parse(typeof(Suit), suit));
                    cards.Add(card);
                }
            }
        }

        /// <summary>
        /// Shuffles the deck 7 times.
        /// </summary>
        public void Shuffle()
        {
            // a deck of cards should be shuffled 7 times for sufficient randomness
            Shuffle(7);
        }

        /// <summary>
        /// Shuffles the deck a specified number of times.
        /// </summary>
        /// <param name="repetitions">The number of times to shuffle the deck.</param>
        public void Shuffle(int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                shuffle<Card>(cards);
            }
        }


        // Shuffle method based on code found at http://stackoverflow.com/questions/273313/randomize-a-listt-in-c

        private void shuffle<T>(List<T> list)
        {
            // create a new random object to help us generate random numbers
            Random rnd = new Random();

            // get the number of cards in the deck
            int n = list.Count;

            while (n > 1)
            {                
                // select a card at random from the range of cards not yet shuffled
                n--;
                int k = rnd.Next(n + 1);
                
                // swap that random card with the last card in the deck.
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
