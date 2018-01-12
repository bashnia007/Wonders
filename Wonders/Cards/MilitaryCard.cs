using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders.Cards
{
    public class MilitaryCard : ICard
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Epoch { get; set; }
        public int MinPlayers { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Gold { get; set; }
        public int Brick { get; set; }
        public int Papirus { get; set; }
        public int Glass { get; set; }
        public int Cloth { get; set; }
        public int Strength { get; set; }
    }
}
