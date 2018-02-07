using Wonders.Enums;

namespace Wonders
{
    public class ResourceForTrade
    {
        public ResourceType ResourceType { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public ResourceForTrade(ResourceType resourceType, int count, int price)
        {
            ResourceType = resourceType;
            Count = count;
            Price = price;
        }
    }
}
