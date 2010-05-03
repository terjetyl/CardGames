using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGames
{
    /// <summary>
    /// A card with a particular suit and rank.
    /// </summary>
    public class Card
    {
        private Rank rank = new Rank();
        private Suit suit = new Suit();
        public Visibility Visibility
        {
            get;
            set;
        }

        // The suit and rank of a card should be publically gettable, but not settable (you cannot change a card in real life).
        // They should also be internal, so that the values of hidden cards cannot be seen in the presentation layer.
        internal Rank Rank
        {
            get { return rank; }
        }
        internal Suit Suit
        {
            get { return suit; }
        }

        public string Name
        {
            get
            {
                if (Visibility == Visibility.Public)
                { 
                    return rank.ToString() + " of " + suit.ToString(); 
                }
                else
                {
                    return "(Hidden)";
                }
            }
        }

        public string ShortName
        {
            get
            {
                if (Visibility == Visibility.Public)
                {
                    string strRank = "";
                    switch (rank.ToString())
                    {
                        case "Ace":
                            strRank = "a";
                            break;
                        case "Two":
                            strRank = "2";
                            break;
                        case "Three":
                            strRank = "3";
                            break;
                        case "Four":
                            strRank = "4";
                            break;
                        case "Five":
                            strRank = "5";
                            break;
                        case "Six":
                            strRank = "6";
                            break;
                        case "Seven":
                            strRank = "7";
                            break;
                        case "Eight":
                            strRank = "8";
                            break;
                        case "Nine":
                            strRank = "9";
                            break;
                        case "Ten":
                            strRank = "t";
                            break;
                        case "Jack":
                            strRank = "j";
                            break;
                        case "Queen":
                            strRank = "q";
                            break;
                        case "King":
                            strRank = "k";
                            break;
                    }

                    return suit.ToString().ToLower()[0].ToString() + strRank;
                }
                else
                {
                    return "hi"; // hidden
                }
            }
        }

        /// <summary>
        /// Creates a new card.
        /// </summary>
        /// <param name="Rank">The new card's rank.</param>
        /// <param name="Suit">The new card's suit.</param>
        public Card(Rank Rank, Suit Suit)
        {
            rank = Rank;
            suit = Suit;
            Visibility = Visibility.Public;
        }

    }
}
