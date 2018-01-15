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
        public Wonder Wonder { get; set; }
        public List<Card> CardsOnHand { get; set; }

        public Player LeftNeighbour { get; set; }

        public Player RightNeighbour { get; set; }

        public List<Card> BuildCards { get; set; }
        public int Coins { get; set; }

        public Dictionary<Resource, int> AvaivableResources { get; set; }
        
        public int Strength { get; set; }

        public Player()
        {
            CardsOnHand = new List<Card>();
        }

        public Decision MakeDecision()
        {
            var rnd = new Random();
            var cardId = rnd.Next(CardsOnHand.Count);
            var selectedCard = CardsOnHand[cardId];
            CardsOnHand.Remove(selectedCard);
            var decisionType = DecisionType.Build;
            var decision = new Decision
            {
                DecisionType = decisionType,
                SelectedCard = selectedCard
            };
            return decision;
        }

        
        private List<Card> GetAvaivableCardsToBuild()
        {
            var freeCards = GetFreeCards();

            foreach (var card in CardsOnHand.Except(freeCards))
            {
                var necessaryResources = new Dictionary<Resource, int>();
                foreach (var cardResource in card.Price)
                {
                    //necessaryResources.Add(cardResource.Key, );
                }
            }

            return null;
        }

        private List<Card> GetFreeCards()
        {
            var result = new List<Card>();
            var linkedCards = CardsOnHand.Where(c => BuildCards.Select(bc => bc.UniqCardId).Contains(c.ParentUniqCard))
                .ToList();
            foreach (var card in CardsOnHand.Except(linkedCards))
            {
                result.AddRange(from avaivableResource in AvaivableResources
                                where card.Price[avaivableResource.Key] <= avaivableResource.Value
                                select card);
            }
            result.AddRange(linkedCards);
            return result;
        }
    }
}
