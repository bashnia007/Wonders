using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wonders;
using Wonders.Cards;

namespace UnitTests
{
    [TestClass]
    public class GameManagerUnitTests
    {
        [TestMethod]
        public void UniqWonderForEachPlayer()
        {
            var players = new List<Player>
            {
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
            };
            var gameManager = new GameManager();

            gameManager.Players = players;
            gameManager.ProvideWonders();
            var groupedPlayers = players.GroupBy(pl => pl.Wonder.Name);
            Assert.IsTrue(groupedPlayers.Any(gr => gr.Count() <= 1));
        }

        [TestMethod]
        public void EachPlayerGets7Cards()
        {
            var players = new List<Player>
            {
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
            };
            var gameManager = new GameManager();
            gameManager.Players = players;
            gameManager.ProvideCards(1);
            Assert.IsTrue(players.All(pl => pl.CardsOnHand.Count == 7));
        }

        [TestMethod]
        public void EachPlayerDroppedOneLasrCard()
        {
            var players = new List<Player>
            {
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
            };
            var gameManager = new GameManager();
            gameManager.Players = players;
            gameManager.ProvideCards(1);
            gameManager.GameProcess();

            Assert.AreEqual(players.Count, gameManager.DropedCards.Count);
        }

        [TestMethod]
        public void TestAddingMilitaryCardToDb()
        {
            var card = new MilitaryCard
            {
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
            };

            DatabaseProvider.AddMilitaryCards(card);
        }
    }
}
