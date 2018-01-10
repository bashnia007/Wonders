using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders
{
    public class GameManager
    {
        private const int EpochCardsAmount = 7;
        private const int EpochsCount = 1;
        private const int CardNumberToPlay = 6;
        public List<Player> Players { get; set; }

        public List<Card> DropedCards;

        public GameManager()
        {
            DropedCards = new List<Card>();
        }

        public void ProvideWonders()
        {
            var wondersList = Enum.GetValues(typeof(WonderType)).Cast<WonderType>().ToList();
            var rnd = new Random();
            foreach (var player in Players)
            {
                var selectedWonderId = rnd.Next(wondersList.Count);
                var selectedSide = rnd.Next(2);

                var wonder = new Wonder(wondersList[selectedWonderId], selectedSide);
                player.Wonder = wonder;
                wondersList.RemoveAt(selectedWonderId);
            }
        }

        public void ProvideCards(int epoch)
        {
            var cards = DatabaseProvider.GetCards(epoch);
            var rnd = new Random();
            foreach (var player in Players)
            {
                for (int i = 0; i < EpochCardsAmount; i++)
                {
                    var selectedCardId = rnd.Next(cards.Count);
                    var card = cards[selectedCardId];

                    player.Cards.Add(card);
                    cards.Remove(card);
                }
            }
        }

        public void GameProcess()
        {
            for (int epoch = 0; epoch < EpochsCount; epoch++)
            {
                for (int cardNumber = 0; cardNumber < CardNumberToPlay; cardNumber++)
                {
                    foreach (var player in Players)
                    {
                        var decision = player.MakeDecision();
                        ComputeSelectedCard(decision);
                    }
                }

                foreach (var player in Players)
                {
                    DropedCards.AddRange(player.Cards);
                }

            }
        }

        private void ComputeSelectedCard(Decision decision)
        {
            switch (decision.DecisionType)
            {
                case DecisionType.Build: break;
                case DecisionType.Drop:
                    DropedCards.Add(decision.SelectedCard);
                    break;
                case DecisionType.UseLikeLevel: break;
            }
        }
    }
}
