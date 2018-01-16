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
    }
}
