namespace Wonders.Enums
{
    public enum TradeType
    {
        /// <summary>
        /// Give 5 coins
        /// </summary>
        Tavern,

        /// <summary>
        /// By primary resources from right neighbour for 1 coin
        /// </summary>
        EastPost,

        /// <summary>
        /// By primary resources from left neighbour for 1 coin
        /// </summary>
        WestPost,

        /// <summary>
        /// By secondary resources from both neighbour for 1 coin
        /// </summary>
        Marketplace,

        /// <summary>
        /// Get free secondary resource
        /// </summary>
        Forum,

        /// <summary>
        /// Get free primary resource
        /// </summary>
        Caravansary,

        /// <summary>
        /// Get 1 coin for each primary resource card of you and both neighbours
        /// </summary>
        Vineyard,

        /// <summary>
        /// Get 2 coin for each secondary resource card of you and both neighbours
        /// </summary>
        Bazar,

        /// <summary>
        /// Get 1 coin and 1 victory point for each primary resource card of you and both neighbours
        /// </summary>
        Haven,

        /// <summary>
        /// Get 1 coin and 1 victory point for each tavern card of you and both neighbours
        /// </summary>
        Lighthouse,

        /// <summary>
        /// Get 1 coin and 1 victory point for each secondary resource card of you and both neighbours
        /// </summary>
        ChamberOfCommerce
    }
}