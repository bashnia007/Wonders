using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders
{
    public class Player
    {
        public Wonder Wonder { get; set; }
        public List<Card> Cards { get; set; }

        public Player()
        {
            Cards = new List<Card>();
        }

        public Decision MakeDecision()
        {
            var rnd = new Random();
            var cardId = rnd.Next(Cards.Count);
            var selectedCard = Cards[cardId];
            Cards.Remove(selectedCard);
            var decisionType = DecisionType.Build;
            var decision = new Decision
            {
                DecisionType = decisionType,
                SelectedCard = selectedCard
            };
            return decision;
        }
    }
}
