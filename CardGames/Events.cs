using System;
namespace CardGames
{
    public delegate void HandChangedEventHandler(object sender, EventArgs e);

    public delegate void BustEventHandler(object sender, BustEventArgs e);

    public delegate void PlayersTurnEventHandler(object sender, EventArgs e);

    public delegate void GameOverEventHandler(object sender, GameOverEventArgs e);

    public class BustEventArgs : EventArgs
    {
        private Person prsn;
        public Person Person
        {
            get { return prsn; }
        }

        public BustEventArgs(Person person)
        {
            this.prsn = person;
        }
    }

    public class GameOverEventArgs : EventArgs
    {
        private Result rslt;
        public Result Result
        {
            get { return rslt; }
        }

        public GameOverEventArgs(Result result)
        {
            this.rslt = result;
        }
    }
}