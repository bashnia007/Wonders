using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wonders;

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
            Assert.IsTrue(players.All(pl => pl.Cards.Count == 7));
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
    }
}
