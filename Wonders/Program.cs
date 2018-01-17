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
            /*var card = new MilitaryCard
            {
                Id = 1,
                Title = "Test military card",
                Strength = 1,
                Brick = 2,
                Cloth = 0,
                Epoch = 1,
                Glass = 1,
                Gold = 1,
                MinPlayers = 5,
                Papirus = 1,
                Stone = 0,
                Wood = 0
            };*/

            //DatabaseProvider.AddMilitaryCards(card);
            DatabaseProvider.AddCards();
            GameManager gameManager = new GameManager();
            //gameManager.ProvideCards(1);

            var cards = DatabaseProvider.ReadAllCards();
        }
    }
}
