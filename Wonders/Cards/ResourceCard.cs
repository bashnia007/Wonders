using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders.Cards
{
    public class ResourceCard : Card
    {
        public Dictionary<ResourceType, int> AvaivableResources => Price;
        public bool Or => AvaivableResources.GroupBy(r => r.Key).Count() > 1;

        public bool IsPrimaryResource => AvaivableResources.ContainsKey(ResourceType.Brick) || AvaivableResources.ContainsKey(ResourceType.Gold) ||
                                         AvaivableResources.ContainsKey(ResourceType.Wood) || AvaivableResources.ContainsKey(ResourceType.Stone);
    }
}
