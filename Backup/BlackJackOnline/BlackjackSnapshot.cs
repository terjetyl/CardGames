using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardGames;

namespace BlackJackOnline
{
    /// <summary>
    /// Contains all the data about a Blackjack game that is
    /// necessary for the presentation layer.
    /// </summary>
    public class BlackjackSnapshot
    {
        private Hand dlrHnd;
        public Hand DealerHand { get { return dlrHnd; } }
        private string dlrTtl;
        public string DealerTotal { get { return dlrTtl; } }
        private bool dlrBst;
        public bool DealerBust { get { return dlrBst; } }
        private int dlrScr;
        public int DealerScore { get { return dlrScr; } }


        private Hand plyrHnd;
        public Hand PlayerHand { get { return plyrHnd; } }
        private string plyrTtl;
        public string PlayerTotal { get { return plyrTtl; } }
        private bool plyrBst;
        public bool PlayerBust { get { return plyrBst; } }
        private int plyrScr;
        public int PlayerScore { get { return plyrScr; } }

        private bool gmInPrgss;
        public bool GameInProgress { get { return gmInPrgss; } }
        
        private int drwCnt;
        public int DrawCount { get { return drwCnt; } }

        private GameOverEventArgs gameOverArgs = null;
        public GameOverEventArgs GameOverArgs { get { return gameOverArgs; } }

        public BlackjackSnapshot(CardGames.Games.Blackjack game)
        {
            dlrHnd = game.DealerHand;
            if (game.InProgress || game.PlayerBust)
            {
                dlrTtl = "?";
            }
            else
            {
                if (game.DealerHand != null)
                {
                    if (game.DealerHand.HandTotal == game.DealerSoftTotal)
                    {
                        dlrTtl = game.DealerHand.HandTotal.ToString();
                    }
                    else
                    {
                        dlrTtl = game.DealerHand.HandTotal.ToString() + " / " + game.DealerSoftTotal.ToString();
                    }
                }
            }
            dlrBst = game.DealerBust;
            dlrScr = game.DealerScore;


            plyrHnd = game.PlayerHand;
            if (game.PlayerHand != null)
            {
                if (game.PlayerHand.HandTotal == game.PlayerSoftTotal)
                {
                    plyrTtl = game.PlayerHand.HandTotal.ToString();
                }
                else
                {
                    plyrTtl = game.PlayerHand.HandTotal.ToString() + " / " + game.PlayerSoftTotal.ToString();
                }
            }

            plyrBst = game.PlayerBust;
            plyrScr = game.PlayerScore;


            drwCnt = game.DrawCount;
            gmInPrgss = game.InProgress;
            gameOverArgs = game.GameOverArgs;
        }
    }
}
