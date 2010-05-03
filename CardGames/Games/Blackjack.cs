using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGames.Games
{
    [Serializable]
    public class Blackjack
    {
        //private List<Deck> decks = new List<Deck>();

        private int dealerScore = 0, playerScore = 0, drawCount = 0;
        private Deck deck;
        private Hand playerHand = new Hand(), dealerHand = new Hand();
        private bool playerBust = false, dealerBust = false;
        private bool gameInProgress = false;
        private GameOverEventArgs gameOverArgs = null;


        public Hand PlayerHand { get { return playerHand; } }
        public Hand DealerHand { get { return dealerHand; } }
        public int DealerScore { get { return dealerScore; } }
        public int PlayerScore { get { return playerScore; } }
        public int DrawCount { get { return drawCount; } }
        public bool PlayerBust { get { return playerBust; } }
        public bool DealerBust { get { return dealerBust; } }
        public bool InProgress { get { return gameInProgress; } }
        public GameOverEventArgs GameOverArgs { get { return gameOverArgs; } }

        

        // soft totals are those that use an ace as 11
        public int DealerSoftTotal { get { return getSoftHandTotal(dealerHand); } }
        public int PlayerSoftTotal { get { return getSoftHandTotal(playerHand); } }
        private int getSoftHandTotal(Hand hand)
        {
            int total = hand.HandTotal;

            // search the hand for an ace
            foreach (Card card in hand.Cards)
            {
                if ((int)card.Rank == 1)
                {
                    // if an ace is found, add 10 to the total
                    total = total + 10;
                    break;
                }
            }
            return total;
        }

        // eval totals get the hand value to evaluate scores by (either hard or soft total)
        private int dealerEvalTotal { get { return getEvalTotal(dealerHand); } }
        private int playerEvalTotal { get { return getEvalTotal(playerHand); } }
        private int getEvalTotal(Hand hand)
        {
            if (getSoftHandTotal(hand) <= 21)
            {
                return getSoftHandTotal(hand);
            }
            else
            {
                return hand.HandTotal;
            }
        }


        public Blackjack()
        {
            
        }

        /// <summary>
        /// Begins a new round of Blackjack.
        /// </summary>
        public void Deal()
        {
            if (gameInProgress)
            {
                return; // do not continue if a game is already in progress.
            }

            gameOverArgs = null;
            gameInProgress = true;

            resetGame();

            dealCardToHand(playerHand);
            dealCardToHand(dealerHand);

            dealCardToHand(playerHand);
            if (gameInProgress == true) // check if this is still true, as game may have moved into Stand() with player's 2nd card.
            {
                dealCardToHand(dealerHand, Visibility.Private);
            }


            OnPlayersTurn(EventArgs.Empty);
        }

        private void resetGame()
        {
            deck = new Deck();
            deck.Shuffle();

            playerHand = new Hand();
            playerHand.HandChanged += new HandChangedEventHandler(playerHand_HandChanged);
            playerBust = false;

            dealerHand = new Hand();
            dealerHand.HandChanged += new HandChangedEventHandler(dealerHand_HandChanged);
            dealerBust = false;
        }

        /// <summary>
        /// Deals a face-up card to a hand.
        /// </summary>
        /// <param name="hand">The hand to deal to.</param>
        /// <returns>Returns true if deal was successful, false if unsuccessful (no cards left in deck).</returns>
        private bool dealCardToHand(Hand hand)
        {
            return dealCardToHand(hand, Visibility.Public);
        }

        /// <summary>
        /// Deals a card to a hand with a specified visibilty
        /// </summary>
        /// <param name="hand">The hand to deal to.</param>
        /// <param name="visibility">The visibilty of the card.</param>
        /// <returns>Returns true if deal was successful, false if unsuccessful (no cards left in deck).</returns>
        private bool dealCardToHand(Hand hand, Visibility visibility)
        {
            if (deck.Cards.Count == 0)
            {
                return false;
            }

            Card card = deck.Cards[0];
            deck.Cards.RemoveAt(0);

            card.Visibility = visibility;
            hand.AddCard(card);
            return true;
        }

        /// <summary>
        /// Causes the player to hit and receive a new card.
        /// </summary>
        public void Hit()
        {
            if (gameInProgress == false)
            {
                return; // don't continue unless a game is in progress.
            }

            dealCardToHand(playerHand);
        }


        /// <summary>
        /// Passes gameplay over to the dealer.
        /// </summary>
        public void Stand()
        {
            if (gameInProgress == false)
            {
                return; // don't continue unless a game is in progress.
            }

            // reveal the hole card (unless not yet dealt, which can be the case when player is dealt 21)
            if (dealerHand.Cards.Count == 2)
            {
                dealerHand.Cards[1].Visibility = Visibility.Public;
                OnDealerHandChanged(EventArgs.Empty);
            }

            
            // dealer hits until hand is 17 or over (dealer stands on both hard and soft 17)
            for (; dealerHand.HandTotal < 17 && DealerSoftTotal < 17; )
            {
                dealCardToHand(dealerHand);

                // TODO (maybe): break out of loop if no cards left in deck (should never happen in a single player game)
            }

            // when dealer has reached 17+, evaluate the scores
            evaluateScores();

            gameInProgress = false;
        }

        void playerHand_HandChanged(object sender, EventArgs e)
        {

            OnPlayerHandChanged(EventArgs.Empty);

            if (playerHand.HandTotal == 21 || PlayerSoftTotal == 21)
            {
                // automatically stand if player's total is 21
                Stand();
            }
            else if (playerHand.HandTotal > 21)
            {
                playerBust = true;
                OnBust(new BustEventArgs(Person.Player));
                evaluateScores();
            }
        }


        void dealerHand_HandChanged(object sender, EventArgs e)
        {

            OnDealerHandChanged(EventArgs.Empty);

            if (dealerHand.HandTotal > 21) 
            {
                dealerBust = true;
                OnBust(new BustEventArgs(Person.Dealer));
            }

        }


        private void evaluateScores()
        {

            if (playerBust)
            {
                dealerScore++;
                gameOverArgs = new GameOverEventArgs(Result.PlayerLoses);
            }
            else if (dealerBust && !playerBust)
            {
                playerScore++;
                gameOverArgs = new GameOverEventArgs(Result.PlayerWins);
            }
            else if (playerEvalTotal > dealerEvalTotal)
            {
                playerScore++;
                gameOverArgs = new GameOverEventArgs(Result.PlayerWins);
            }
            else if (playerEvalTotal < dealerEvalTotal)
            {
                dealerScore++;
                gameOverArgs = new GameOverEventArgs(Result.PlayerLoses);
            }
            else
            {
                ++drawCount;
                gameOverArgs = new GameOverEventArgs(Result.Draw);
            }

            gameInProgress = false;
            OnGameOver(gameOverArgs);

        }





        #region eventHandlers

        public event HandChangedEventHandler PlayerHandChanged;
        protected void OnPlayerHandChanged(EventArgs e)
        {
            if (PlayerHandChanged != null)
            {
                PlayerHandChanged(this, e);
            }
        }

        public event HandChangedEventHandler DealerHandChanged;
        protected void OnDealerHandChanged(EventArgs e)
        {
            if (DealerHandChanged != null)
            {
                DealerHandChanged(this, e);
            }
        }

        public event GameOverEventHandler GameOver;
        protected void OnGameOver(GameOverEventArgs e)
        {
            if (GameOver != null)
            {
                GameOver(this, e);
            }
        }

        public event BustEventHandler Bust;
        protected void OnBust(BustEventArgs e)
        {
            if (Bust != null)
            {
                Bust(this, e);
            }
        }

        public event PlayersTurnEventHandler PlayersTurn;
        protected void OnPlayersTurn(EventArgs e)
        {
            if (PlayersTurn != null)
            {
                PlayersTurn(this, e);
            }
        }

        #endregion
    }
}
