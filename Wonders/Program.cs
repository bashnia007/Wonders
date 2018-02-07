using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;

namespace Wonders
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseProvider.AddCards();

            var cards = DatabaseProvider.ReadAllCards();
            GameManager gameManager = new GameManager();
            gameManager.GameCards = cards;

            //todo fill Players
//            gameManager.Players = new List<Player>
//            {
//                new Player(),
//                new Player(),
//                new Player()
//            };
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            var player4 = new Player();
            player1.Id = 1;
            player1.LeftNeighbour = player2;
            player1.RightNeighbour = player4;

            player2.Id = 2;
            player2.LeftNeighbour = player3;
            player2.RightNeighbour = player1;

            player3.Id = 3;
            player3.LeftNeighbour = player4;
            player3.RightNeighbour = player2;

            player4.Id = 4;
            player4.LeftNeighbour = player1;
            player4.RightNeighbour = player3;

            gameManager.Players = new List<Player>();
            gameManager.Players.Add(player1);
            gameManager.Players.Add(player2);
            gameManager.Players.Add(player3);
            gameManager.Players.Add(player4);
            //gameManager.ProvideCards(1);

            gameManager.GameProcess();
        }
    }
}
