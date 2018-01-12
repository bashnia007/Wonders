using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders.Cards
{
    public class ResourceCard : ICard
    {
        public string Title { get; set; }
        public int Epoch { get; set; }
        public Dictionary<Resource, int> Price { get; set; }
        public int MaxPlayers { get; set; }
        public int CointsPrice { get; set; }
    }
}
