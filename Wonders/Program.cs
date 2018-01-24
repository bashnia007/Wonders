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
            gameManager.Players = new List<Player>
            {
                new Player(),
                new Player(),
                new Player()
            };
            gameManager.ProvideCards(1);
        }
    }
}
