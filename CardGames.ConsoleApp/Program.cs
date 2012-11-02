using System;
using CardGames.Games;

namespace CardGames.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name of player1:");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter name of player2:");
            string name2 = Console.ReadLine();

            var game = new FemKort(new Player(name1), new Player(name2));
            game.ShuffleAndDeal();

            while (game.GetWinner() == null)
            {
                Console.WriteLine("Your hand {0}:", game.CurrentHand.Player.Name);

                DisplayHand(game.CurrentHand);

                Console.WriteLine("Play your card {0}", game.CurrentHand.Player.Name);
                string shortName = Console.ReadLine();

                var card2 = game.CurrentHand.GetCardByShortName(shortName);
                if(card2 == null)
                {
                    Console.WriteLine("Invalid card");
                }
                else
                {
                    game.PlayRound(game.CurrentHand.Player, game.CurrentHand.PlayCard(shortName));
                    Console.WriteLine("You played card: " + card2.Name);
                }  
            }
            Console.WriteLine("Winner is {0} with {1} wins", game.GetWinner().Item1.Name, game.GetWinner().Item2);
        }

        private static void DisplayHand(Hand hand)
        {
            foreach (var card in hand.Cards)
            {
                Console.WriteLine(card.Name + ", " + card.ShortName);
            }
        }
    }
}
