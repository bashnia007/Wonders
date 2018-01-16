using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    public class Neighbour : Player
    {
        public Player Player { get; set; }

        public List<ResourceForTrade> ResourcesForTrade
        {
            get
            {
                //if(Player)
                return null;
            }
        }
    }
    public class ResourceForTrade
    {
        public ResourceType ResourceType { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
