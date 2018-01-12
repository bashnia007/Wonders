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
        public ICard SelectedCard { get; set; }
        public DecisionType DecisionType { get; set; }
    }
}
