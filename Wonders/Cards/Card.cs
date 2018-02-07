using System;
using System.Collections.Generic;
using Wonders.Enums;

namespace Wonders.Cards
{
    public class Card : DbCard
    {
        public Dictionary<ResourceType, int> Price => new Dictionary<ResourceType, int>
        {
            {ResourceType.Brick, Brick},
            {ResourceType.Wood, Wood},
            {ResourceType.Cloth, Cloth},
            {ResourceType.Glass, Glass},
            {ResourceType.Gold, Gold},
            {ResourceType.Papirus, Papirus},
            {ResourceType.Stone, Stone}
        };
    }
}
