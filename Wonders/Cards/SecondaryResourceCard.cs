using System.Collections.Generic;
using Wonders.Enums;

namespace Wonders.Cards
{
    public class SecondaryResourceCard : Card
    {
        public Dictionary<ResourceType, int> AvaivableResources => Price;
    }
}
