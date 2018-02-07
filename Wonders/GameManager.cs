using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;
using Wonders.Enums;
using Wonders.Helpers;

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
                    player.CardsOnHand = new List<Card>();
                }
                ResolveBattles(epoch);
            }
        }

        private void TransferCards(int epoch)
        {
            var savedcards = new List<Card>[4];
            for (int i = 0; i < Players.Count; i++)
            {
                savedcards[i] = Players[i].CardsOnHand.Select(ObjectCopier.Clone).ToList();
            }
            if (epoch % 2 != 0)
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    Players[i].CardsOnHand = savedcards[(i + 1) % Players.Count];
                }
            }
            else
            {
                for (int i = Players.Count - 1; i >= 0; i--)
                {
                    Players[i].CardsOnHand = savedcards[(Players.Count + i - 1) % Players.Count];
                }
            }
            
        }

        private void ComputeSelectedCard(Player player, Decision decision)
        {
            switch (decision.DecisionType)
            {
                case DecisionType.BuildByResources:
                    BuildCard(false, player, decision);
                    break;
                case DecisionType.BuildByLink:
                    BuildCard(true, player, decision);
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

	    private void BuildCard(bool isLink, Player player, Decision decision)
	    {
            if(!isLink) MakeTransfers(player, decision);
	        player.BuildCards.Add(decision.SelectedCard);
	        ExecuteEffectOfCard(player, decision.SelectedCard);
	    }

        private void MakeTransfers(Player player, Decision decision)
        {
            if (decision.DecisionType != DecisionType.BuildByResources) return;
            player.Coins -= decision.SelectedCard.CoinsCost;
            foreach (var leftCard in decision.UsedLeftCards)
            {
                if (leftCard.IsPrimaryResource)
                {
                    
                }
            }
        }

        private void ExecuteEffectOfCard(Player player, Card card)
        {
            switch ((CardType)card.CardType)
            {
                case CardType.MilitaryCard:
                    player.Strength += card.CardBenefit;
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
