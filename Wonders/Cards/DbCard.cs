using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders.Cards
{
    public abstract class DbCard
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UniqCardId { get; set; }
        public int CardType { get; set; }
        public int Epoch { get; set; }
        public int MinPlayers { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Gold { get; set; }
        public int Brick { get; set; }
        public int Papirus { get; set; }
        public int Glass { get; set; }
        public int Cloth { get; set; }
        public int CardBenefit { get; set; }
        public int CoinsCost { get; set; }
    }
}
