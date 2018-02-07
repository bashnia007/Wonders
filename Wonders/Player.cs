using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;
using Wonders.Enums;

namespace Wonders
{
    public class Player
    {
        public int Id { get; set; }
        public Wonder Wonder { get; set; }
        public List<Card> CardsOnHand { get; set; }

        public Player LeftNeighbour { get; set; }

        public Player RightNeighbour { get; set; }

        public List<Card> BuildCards { get; set; }
        public int Coins { get; set; }

        public Dictionary<ResourceType, int> AvaivableResources { get; set; }

        public List<ResourceCard> ResourceCards { get; set; }
        
        public int Strength { get; set; }
        
        public List<ResourceForTrade> LeftNeighbourResources => GetResourcesForTradeOfNeighbour(TradeType.WestPost, TradeType.Marketplace);

        public List<ResourceForTrade> RightNeighbourResources => GetResourcesForTradeOfNeighbour(TradeType.EastPost, TradeType.Marketplace);
        
        public List<MilitaryBadge> MilitaryBadges { get; set; }
        public Player()
        {
            CardsOnHand = new List<Card>();
            AvaivableResources = new Dictionary<ResourceType, int>
            {
                { ResourceType.Brick, 0 },
                { ResourceType.Gold, 0 },
                { ResourceType.Stone, 0 },
                { ResourceType.Wood, 0 },
                { ResourceType.Glass, 0 },
                { ResourceType.Papirus, 0 },
                { ResourceType.Cloth, 0 }
            };
            BuildCards = new List<Card>();
            ResourceCards = new List<ResourceCard>();
            Coins = 3;
            MilitaryBadges = new List<MilitaryBadge>();
        }

        public Decision MakeDecision()
        {
            var rnd = new Random();
            /*var avaivableCards = GetAvaivableCardsToBuild();
            var cardId = rnd.Next(avaivableCards.Count);
            var selectedCard = avaivableCards[cardId];
            CardsOnHand.Remove(selectedCard);
            var decisionType = DecisionType.BuildByResources;
            var decision = new Decision
            {
                DecisionType = decisionType,
                SelectedCard = selectedCard
            };
            switch (decisionType)
            {
                case DecisionType.BuildByResources:
                    BuildCard(selectedCard);
                    break;
            }*/
            var decision = new Decision();
            decision.SelectedCard = CardsOnHand.FirstOrDefault();
            decision.DecisionType = (DecisionType) rnd.Next(Enum.GetValues(typeof(DecisionType)).Length);
            return decision;
        }

        private void BuildCard(Card selectedCard)
        {
            Pay(selectedCard);
            switch (selectedCard.CardType)
            {
                case (int)CardType.ResourceCard:
                    BuildResourceCard(selectedCard as ResourceCard);
                    break;
                case (int)CardType.MilitaryCard: break;
                case (int)CardType.CultureCard: break;
                case (int)CardType.ScienceCard: break;
                case (int)CardType.TradeCard: break;
            }
        }

        private void BuildResourceCard(ResourceCard card)
        {
            foreach (var avaivableResource in card.AvaivableResources)
            {
                if (AvaivableResources.ContainsKey(avaivableResource.Key))
                    AvaivableResources[avaivableResource.Key] += avaivableResource.Value;
                else
                {
                    AvaivableResources.Add(avaivableResource.Key, avaivableResource.Value);
                }
            }
        }

        private void Pay(Card card)
        {
            Coins -= card.CoinsCost;
        }
        
        private List<Card> GetAvaivableCardsToBuild()
        {
            var freeCards = GetFreeCards();
            var avaivableCards = new List<Card>();
            foreach (var card in CardsOnHand.Except(freeCards))
            {
                var necessaryResources = new Dictionary<ResourceType, int>();
                // calculating all necessary resources for each card
                foreach (var cardResource in card.Price)
                {
                    int difference = cardResource.Value - AvaivableResources[cardResource.Key];
                    if (difference > 0)
                    {
                        necessaryResources.Add(cardResource.Key, difference);
                    }
                }
                // this if shouldn't executed
                if (necessaryResources.All(r => r.Value == 0))
                {
                    avaivableCards.Add(card);
                    continue;
                }
                int summaryPrice = 0;
                // calculating is it enough resources for trade from neighbours and is it enough coins to buy it
                foreach (var necessaryResource in necessaryResources)
                {
                    var left = LeftNeighbourResources.First(r => r.ResourceType == necessaryResource.Key);
                    var right = RightNeighbourResources.First(r => r.ResourceType == necessaryResource.Key);
                    var count = left.Count + right.Count;
                    if (necessaryResource.Value > count) break;
                    var minimal = left.Price <= right.Price ? left : right;
                    var maximum = left.Price <= right.Price ? right : left;
                    var toBuyCheap = Math.Min(necessaryResource.Value, minimal.Count);
                    summaryPrice += toBuyCheap * minimal.Price;
                    var toBuyExpensive = necessaryResource.Value - toBuyCheap;
                    summaryPrice += toBuyExpensive * maximum.Price;
                }
                if (summaryPrice <= Coins)
                {
                    avaivableCards.Add(card);
                }
            }
            

            return avaivableCards;
        }

        // returns cards which player can build by his resources or by links between cards
        private List<Card> GetFreeCards()
        {
            var result = new List<Card>();
            var linkedCards = CardsOnHand.Where(c => BuildCards.Select(bc => bc.UniqCardId).Contains(c.ParentUniqCard))
                .ToList();
            foreach (var card in CardsOnHand.Except(linkedCards))
            {
                if (card.CardType == (int) CardType.ResourceCard)
                {
                    if(Coins >= card.CoinsCost) result.Add(card);
                    continue;
                }
//                var isEnough = card.Price.All(resource => AvaivableResources[resource.Key] > resource.Value);
//                if(isEnough) result.Add(card);
            }
            result.AddRange(linkedCards);
            return result;
        }

        private List<ResourceForTrade> GetResourcesForTradeOfNeighbour(TradeType primaryDiscountCardType, TradeType seconadryDiscountCardType)
        {
            var result = new List<ResourceForTrade>();
            var cheapPrimary = CardsOnHand.Any(c =>
                c.CardType == (int)CardType.TradeCard && c.CardBenefit == (int)primaryDiscountCardType);
            var cheapSecondary = CardsOnHand.Any(c =>
                c.CardType == (int)CardType.TradeCard && c.CardBenefit == (int)seconadryDiscountCardType);
            foreach (var resource in LeftNeighbour.AvaivableResources)
            {
                switch (resource.Key)
                {
                    case ResourceType.Brick:
                    case ResourceType.Wood:
                    case ResourceType.Stone:
                    case ResourceType.Gold:
                        result.Add(new ResourceForTrade(resource.Key, resource.Value, cheapPrimary ? 1 : 2));
                        break;
                    case ResourceType.Glass: 
                    case ResourceType.Papirus: 
                    case ResourceType.Cloth:
                        result.Add(new ResourceForTrade(resource.Key, resource.Value, cheapSecondary ? 1 : 2));
                        break;
                }
            }
            return result;
        }
    }
}
