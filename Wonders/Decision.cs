using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;
using Wonders.Enums;

namespace Wonders
{
    public class Decision
    {
        public Card SelectedCard { get; set; }
        public DecisionType DecisionType { get; set; }
        public List<Card> UsedCards { get; set; }
        public List<ResourceCard> UsedLeftCards { get; set; }
        public List<ResourceCard> UsedRightCards { get; set; }
    }
}
