using Wonders.Enums;

namespace Wonders.Cards
{
    public class TradeCard : Card
    {
        public TradeType TradeType => (TradeType) CardBenefit;
    }
}
