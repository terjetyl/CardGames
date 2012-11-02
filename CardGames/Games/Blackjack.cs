using System;

namespace CardGames.Games
{
    [Serializable]
    public class Blackjack
    {
        //private List<Deck> decks = new List<Deck>();

        private int _dealerScore;
        private int _drawCount;
        private int _playerScore;
        private bool _dealerBust;
        private Hand _dealerHand;
        private Deck _deck;
        private bool _gameInProgress;
        private GameOverEventArgs _gameOverArgs;
        private bool _playerBust;
        private Hand _playerHand;


        public Hand PlayerHand
        {
            get { return _playerHand; }
        }

        public Hand DealerHand
        {
            get { return _dealerHand; }
        }

        public int DealerScore
        {
            get { return _dealerScore; }
        }

        public int PlayerScore
        {
            get { return _playerScore; }
        }

        public int DrawCount
        {
            get { return _drawCount; }
        }

        public bool PlayerBust
        {
            get { return _playerBust; }
        }

        public bool DealerBust
        {
            get { return _dealerBust; }
        }

        public bool InProgress
        {
            get { return _gameInProgress; }
        }

        public GameOverEventArgs GameOverArgs
        {
            get { return _gameOverArgs; }
        }


        // soft totals are those that use an ace as 11
        public int DealerSoftTotal
        {
            get { return getSoftHandTotal(_dealerHand); }
        }

        public int PlayerSoftTotal
        {
            get { return getSoftHandTotal(_playerHand); }
        }

        // eval totals get the hand value to evaluate scores by (either hard or soft total)
        private int dealerEvalTotal
        {
            get { return getEvalTotal(_dealerHand); }
        }

        private int playerEvalTotal
        {
            get { return getEvalTotal(_playerHand); }
        }

        private int getSoftHandTotal(Hand hand)
        {
            int total = hand.HandTotal;

            // search the hand for an ace
            foreach (Card card in hand.Cards)
            {
                if ((int) card.Rank == 1)
                {
                    // if an ace is found, add 10 to the total
                    total = total + 10;
                    break;
                }
            }
            return total;
        }

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


        /// <summary>
        ///     Begins a new round of Blackjack.
        /// </summary>
        public void Deal()
        {
            if (_gameInProgress)
            {
                return; // do not continue if a game is already in progress.
            }

            _gameOverArgs = null;
            _gameInProgress = true;

            resetGame();

            dealCardToHand(_playerHand);
            dealCardToHand(_dealerHand);

            dealCardToHand(_playerHand);
            if (_gameInProgress)
                // check if this is still true, as game may have moved into Stand() with player's 2nd card.
            {
                dealCardToHand(_dealerHand, Visibility.Closed);
            }


            OnPlayersTurn(EventArgs.Empty);
        }

        private void resetGame()
        {
            _deck = new Deck();
            _deck.Shuffle();

            _playerHand = new Hand(new Player("ds"));
            _playerHand.HandChanged += playerHand_HandChanged;
            _playerBust = false;

            _dealerHand = new Hand(new Player("ds"));
            _dealerHand.HandChanged += dealerHand_HandChanged;
            _dealerBust = false;
        }

        /// <summary>
        ///     Deals a face-up card to a hand.
        /// </summary>
        /// <param name="hand"> The hand to deal to. </param>
        /// <returns> Returns true if deal was successful, false if unsuccessful (no cards left in deck). </returns>
        private bool dealCardToHand(Hand hand)
        {
            return dealCardToHand(hand, Visibility.Open);
        }

        /// <summary>
        ///     Deals a card to a hand with a specified visibilty
        /// </summary>
        /// <param name="hand"> The hand to deal to. </param>
        /// <param name="visibility"> The visibilty of the card. </param>
        /// <returns> Returns true if deal was successful, false if unsuccessful (no cards left in deck). </returns>
        private bool dealCardToHand(Hand hand, Visibility visibility)
        {
            if (_deck.Cards.Count == 0)
            {
                return false;
            }

            Card card = _deck.Cards[0];
            _deck.Cards.RemoveAt(0);

            card.Visibility = visibility;
            hand.AddCard(card);
            return true;
        }

        /// <summary>
        ///     Causes the player to hit and receive a new card.
        /// </summary>
        public void Hit()
        {
            if (_gameInProgress == false)
            {
                return; // don't continue unless a game is in progress.
            }

            dealCardToHand(_playerHand);
        }


        /// <summary>
        ///     Passes gameplay over to the dealer.
        /// </summary>
        public void Stand()
        {
            if (_gameInProgress == false)
            {
                return; // don't continue unless a game is in progress.
            }

            // reveal the hole card (unless not yet dealt, which can be the case when player is dealt 21)
            if (_dealerHand.Cards.Count == 2)
            {
                _dealerHand.Cards[1].Visibility = Visibility.Open;
                OnDealerHandChanged(EventArgs.Empty);
            }


            // dealer hits until hand is 17 or over (dealer stands on both hard and soft 17)
            for (; _dealerHand.HandTotal < 17 && DealerSoftTotal < 17;)
            {
                dealCardToHand(_dealerHand);

                // TODO (maybe): break out of loop if no cards left in deck (should never happen in a single player game)
            }

            // when dealer has reached 17+, evaluate the scores
            evaluateScores();

            _gameInProgress = false;
        }

        private void playerHand_HandChanged(object sender, EventArgs e)
        {
            OnPlayerHandChanged(EventArgs.Empty);

            if (_playerHand.HandTotal == 21 || PlayerSoftTotal == 21)
            {
                // automatically stand if player's total is 21
                Stand();
            }
            else if (_playerHand.HandTotal > 21)
            {
                _playerBust = true;
                OnBust(new BustEventArgs(Person.Player));
                evaluateScores();
            }
        }


        private void dealerHand_HandChanged(object sender, EventArgs e)
        {
            OnDealerHandChanged(EventArgs.Empty);

            if (_dealerHand.HandTotal > 21)
            {
                _dealerBust = true;
                OnBust(new BustEventArgs(Person.Dealer));
            }
        }


        private void evaluateScores()
        {
            if (_playerBust)
            {
                _dealerScore++;
                _gameOverArgs = new GameOverEventArgs(Result.PlayerLoses);
            }
            else if (_dealerBust && !_playerBust)
            {
                _playerScore++;
                _gameOverArgs = new GameOverEventArgs(Result.PlayerWins);
            }
            else if (playerEvalTotal > dealerEvalTotal)
            {
                _playerScore++;
                _gameOverArgs = new GameOverEventArgs(Result.PlayerWins);
            }
            else if (playerEvalTotal < dealerEvalTotal)
            {
                _dealerScore++;
                _gameOverArgs = new GameOverEventArgs(Result.PlayerLoses);
            }
            else
            {
                ++_drawCount;
                _gameOverArgs = new GameOverEventArgs(Result.Draw);
            }

            _gameInProgress = false;
            OnGameOver(_gameOverArgs);
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