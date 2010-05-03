using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CardGames;
using CardGames.Games;
using System.Xml;

namespace BlackJackOnline
{
    /// <summary>
    /// Summary description for BlackjackWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class BlackjackWebService : System.Web.Services.WebService
    {
        private Blackjack _game = null;
        /// <summary>
        /// Getting this variable will return an old game if one exists in session, or a new game if not.
        /// </summary>
        private Blackjack game
        {
            get
            {
                if (_game == null)
                {
                    if (Session["game"] == null)
                    {
                        _game = new Blackjack();
                    }
                    else
                    {
                        _game = (Blackjack)Session["game"];
                    }
                }
                return _game;
            }
        }

        //private bool playersTurn = false;

        public BlackjackWebService()
        {

        }


        /// <summary>
        /// Gets a BlackjackSnapshot object that contains game data to be sent to the presentation layer.
        /// </summary>
        private BlackjackSnapshot snapshot
        {
            get
            {
                BlackjackSnapshot snap = new BlackjackSnapshot(game);
                return snap;
            }
        }



        // Each of the following three WebMethods reloads the game 
        // from session state and calls the associated game method.
        // The game is then saved back to the session in it's new 
        // state, and the game details are returned for use in the
        // presentation layer.
        
        [WebMethod(EnableSession = true)]
        public BlackjackSnapshot Deal()
        {
            game.Deal();

            Session["game"] = game;
            return snapshot;
        }

        [WebMethod(EnableSession = true)]
        public BlackjackSnapshot Hit()
        {
            game.Hit();

            Session["game"] = game;
            return snapshot;
        }

        [WebMethod(EnableSession = true)]
        public BlackjackSnapshot Stand()
        {
            game.Stand();

            Session["game"] = game;
            return snapshot;
        }



        // This final method returns the game data without making any changes to the game.
        // This can be called when the game is first loaded in the browser, or when
        // the page is refreshed accidentally, etc.

        [WebMethod(EnableSession=true)]
        public BlackjackSnapshot GetSnapshot()
        {
            return snapshot;
        }


    }
}
