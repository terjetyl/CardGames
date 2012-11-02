using CardGames.Games;
using SignalR.Hubs;

namespace CardGames.Web.Hubs
{
    public class CardHub : Hub
    {
        private FemKort _femKort;
        
        public void StartGame(string name1, string name2)
        {
            Caller.name = name1;
            var player1 = new Player(name1);
            var player2 = new Player(name2);
            _femKort = new FemKort(player1, player2);
            _femKort.ShuffleAndDeal();
            Caller.DrawHandCaller(_femKort.Hand1);
            Clients.DrawHand(name1, _femKort.Hand2);
        }
    }
}