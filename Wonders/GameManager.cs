using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;
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

        public List<Card> GameCards { get; set; }

        public int VictoryPoints { get; set; }

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
            if (GameCards == null)
            {
                throw new Exception("There are no cards!");
            }
            if (Players == null)
            {
                throw new Exception("There are no players!");
            }
            var rnd = new Random();
            var cardsForCurrentPlayersNumber = GameCards.Where(c => c.MinPlayers <= Players.Count).ToList();
            foreach (var player in Players)
            {
                for (int i = 0; i < EpochCardsAmount; i++)
                {
                    var selectedCardId = rnd.Next(cardsForCurrentPlayersNumber.Count);
                    var card = cardsForCurrentPlayersNumber[selectedCardId];

                    player.CardsOnHand.Add(card);
                    cardsForCurrentPlayersNumber.Remove(card);
                }
            }
        }

        public void GameProcess()
        {
            for (int epoch = 1; epoch <= EpochsCount; epoch++)
            {
                ProvideCards(epoch);
                for (int cardNumber = 0; cardNumber < CardNumberToPlay; cardNumber++)
                {
                    foreach (var player in Players)
                    {
                        var decision = player.MakeDecision();
                        if(IsDecisionAvaivable(decision)) ComputeSelectedCard(player, decision);
                    }
                    TransferCards(epoch);
                }

                // drop last card
                foreach (var player in Players)
                {
                    DropedCards.AddRange(player.CardsOnHand);
                }
                ResolveBattles(epoch);
            }
        }

        private void TransferCards(int epoch)
        {
            var temp = Players[0].CardsOnHand;
            if (epoch % 2 == 0)
            {
                foreach (var player in Players)
                {
                    player.CardsOnHand = player.LeftNeighbour.CardsOnHand;
                }
            }
            else
            {
                foreach (var player in Players)
                {
                    player.CardsOnHand = player.RightNeighbour.CardsOnHand;
                }
            }
            Players[Players.Count - 1].CardsOnHand = temp;
        }

        private void ComputeSelectedCard(Player player, Decision decision)
        {
            switch (decision.DecisionType)
            {
                case DecisionType.BuildByResources:
                    BuildCard(player, decision);
                    break;
                case DecisionType.BuildByLink:
                    player.BuildCards.Add(decision.SelectedCard);
                    break;
                case DecisionType.Drop:
                    player.Coins += 3;
                    DropedCards.Add(decision.SelectedCard);
                    break;
//                case DecisionType.UseLikeLevel: break;
            }
            player.CardsOnHand.Remove(decision.SelectedCard);
        }

        public void ResolveBattles(int epoch)
        {
            foreach (var player in Players)
            {
                CalculateBattle(player, player.LeftNeighbour, epoch);
                CalculateBattle(player, player.RightNeighbour, epoch);
            }
        }

        private void CalculateBattle(Player player, Player neighbour, int epoch)
        {
            if (player.Strength < neighbour.Strength)
            {
                player.MilitaryBadges.Add(new MilitaryBadge(MilitaryBadgeType.Lose));
            }
            if (player.Strength > neighbour.Strength)
            {
                player.MilitaryBadges.Add(new MilitaryBadge((MilitaryBadgeType) epoch));
            }
        }

	    private void BuildCard(Player player, Decision decision)
	    {
            MakeTransfers(player, decision);
	        player.BuildCards.Add(decision.SelectedCard);
	        ExecuteEffectOfCard(player, decision.SelectedCard);
	    }

        private void MakeTransfers(Player player, Decision decision)
        {
            
        }

        private void ExecuteEffectOfCard(Player player, Card card)
        {
            switch ((CardType)card.CardType)
            {
                case CardType.MilitaryCard:
                    var militaryCard = (MilitaryCard)card;
                    player.Strength += militaryCard.Strength;
                    break;
            }
        }

        private bool IsDecisionAvaivable(Decision decision)
        {
            return true;
        }

        private void BuildLevel(Player player)
        {
            
        }
    }
}
