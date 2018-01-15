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
        public List<ICard> CardsOnHand { get; set; }

        public Player LeftNeighbour { get; set; }

        public Player RightNeighbour { get; set; }

        public List<ICard> BuildCards { get; set; }
        public int Coins { get; set; }

        public Dictionary<Resource, int> AvaivableResources { get; set; }
        
        public int Strength { get; set; }

        public Player()
        {
            CardsOnHand = new List<ICard>();
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

        /*
        private List<ICard> GetAvaivableCardsToBuild()
        {
            foreach (var card in CardsOnHand)
            {
                var necessaryResources = 
            }
        }*/
    }
}
