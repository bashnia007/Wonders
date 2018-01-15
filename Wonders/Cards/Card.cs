using System.Collections.Generic;
using Wonders.Enums;

namespace Wonders.Cards
{
    public class Card : DbCard
    {
        public Dictionary<Resource, int> Price => new Dictionary<Resource, int>
        {
            {Resource.Brick, Brick},
            {Resource.Wood, Wood},
            {Resource.Cloth, Cloth},
            {Resource.Glass, Glass},
            {Resource.Gold, Gold},
            {Resource.Papirus, Papirus},
            {Resource.Stone, Stone}
        };
    }
}
