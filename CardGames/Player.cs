namespace CardGames
{
    public class Player
    {
        private readonly string _name;

        public Player(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}