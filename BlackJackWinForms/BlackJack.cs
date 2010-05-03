using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardGames;

namespace BlackJackWinForms
{
    public partial class BlackJack : Form
    {
        private CardGames.Games.Blackjack game = new CardGames.Games.Blackjack();

        public BlackJack()
        {
            InitializeComponent();

            //lbxHand.DataSource = game.Hand.Cards;
            //lbxHand.DisplayMember = "Name";

            game.PlayerHandChanged += new HandChangedEventHandler(PlayerHand_HandChanged);
            game.DealerHandChanged += new HandChangedEventHandler(DealerHand_HandChanged);
            game.Bust += new BustEventHandler(game_Bust);
            game.PlayersTurn += new PlayersTurnEventHandler(game_PlayersTurn);
            game.GameOver += new GameOverEventHandler(game_GameOver);
        }

        void game_GameOver(object sender, GameOverEventArgs e)
        {

            switch (e.Result)
            {
                case Result.Draw:
                    lblDraw.Visible = true;
                    break;
                case Result.PlayerLoses:
                    lblDealerWin.Visible = true;
                    break;
                case Result.PlayerWins:
                    lblPlayerWin.Visible = true;
                    break;
            }
            refreshScores();
            resetGame();
       }

        private void refreshScores()
        {
            lblDealerScore.Text = game.DealerScore.ToString();
            lblPlayerScore.Text = game.PlayerScore.ToString();
            lblDrawCount.Text = game.DrawCount.ToString();
        }

        void game_PlayersTurn(object sender, EventArgs e)
        {
            lblPlayerBust.Visible = false;
            lblDealerBust.Visible = false;

            btnHit.Enabled = true;
            btnStand.Enabled = true;
            
            btnDeal.Enabled = false;
        }


        void game_Bust(object sender, BustEventArgs e)
        {
            if (e.Person == Person.Player)
            {
                lblPlayerBust.Visible = true;
            }
            else if (e.Person == Person.Dealer)
            {
                lblDealerBust.Visible = true;
            }

            resetGame();
        }


        private void resetGame()
        {
            btnHit.Enabled = false;
            btnStand.Enabled = false;

            btnDeal.Enabled = true;
        }


        void PlayerHand_HandChanged(object sender, EventArgs e)
        {
            refreshHand(lbxPlayerHand, game.PlayerHand);
            lblPlayerTotals.Text = String.Format("{0} / {1}", game.PlayerHand.HandTotal.ToString(), game.PlayerSoftTotal.ToString());
        }

        void DealerHand_HandChanged(object sender, EventArgs e)
        {
            refreshHand(lbxDealerHand, game.DealerHand);
            lblDealerTotals.Text = String.Format("{0} / {1}", game.DealerHand.HandTotal.ToString(), game.DealerSoftTotal.ToString());
        }

        private void refreshHand(ListBox lbx, Hand hand)
        {
            lbx.Items.Clear();
            foreach (Card card in hand.Cards)
            {
                lbx.Items.Add(card.Name);
            }
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            lblPlayerWin.Visible = false;
            lblDealerWin.Visible = false;
            lblDraw.Visible = false;
            game.Deal();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            game.Hit();
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            game.Stand();
        }


    }
}
